using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DeepL;
using DeepL.Model;
using FaraBotModerator.models;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;
using TwitchLib.PubSub.Events;
using OnLogArgs = TwitchLib.Client.Events.OnLogArgs;

namespace FaraBotModerator.controllers
{
    /// <summary>
    /// Twitch Client経由の操作をするController
    /// </summary>
    public class TwitchClientController
    {
        private readonly SecretKeyModel _secretKeys;
        private readonly TwitchClient _twitchClient;
        private readonly TwitchApiController _twitchApiController;
        private readonly string _twitchUserName;
        private BouyomiChanController _bouyomiChanController = new();
        private Queue<ChatModel> _chatDataQueue = new();
        private Translator _deepLTranslator;
        private bool _pubsubFailure = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secretKeys"></param>
        /// <param name="twitchApiController"></param>
        public TwitchClientController(SecretKeyModel secretKeys, TwitchApiController twitchApiController)
        {
            _secretKeys = secretKeys;
            _twitchApiController = twitchApiController;
            _deepLTranslator = new Translator(_secretKeys.DeepL.ApiKey);

            var client = _secretKeys.Twitch.Client;
            ConnectionCredentials credentials = new ConnectionCredentials(client.UserName, client.AccessToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            var customClient = new WebSocketClient(clientOptions);
            _twitchClient = new TwitchClient(customClient);
            _twitchClient.Initialize(credentials, client.UserName);

            _twitchClient.OnLog += TwitchClientOnLog;
            _twitchClient.OnJoinedChannel += TwitchClientOnJoinedChannel;
            _twitchClient.OnMessageReceived += TwitchClientOnMessageReceived;
            _twitchClient.OnNewSubscriber += TwitchClientOnNewSubscriber;
            _twitchClient.OnReSubscriber += TwitchClientOnReSubscriber;
            _twitchClient.OnGiftedSubscription += TwitchClientOnGiftedSubscription;
            _twitchClient.OnRaidNotification += TwitchClientOnRaidNotification;
            _twitchClient.OnConnected += TwitchClientOnConnected;
            _twitchClient.OnDisconnected += TwitchClientOnDisconnected;
            // OnDisconnectedはタイムラグの関係で実装しない

            _twitchUserName = _twitchClient.TwitchUsername;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Connect()
        {
            _twitchClient.Connect();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Disconnect()
        {
            _deepLTranslator.Dispose();
            _twitchClient.Disconnect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void SendModeratorMessage(string message)
        {
            SendMessage(_twitchUserName, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        private void SendMessage(string userName, string message)
        {
            _twitchClient.SendMessage(_twitchUserName, message);
            AddChatListData(userName, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ChatModel? PickChatData()
        {
            return _chatDataQueue.Count > 0 ? _chatDataQueue.Dequeue() : null;
        }

        /// <summary>
        /// 指定URLの画像をStream型で取得
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private void AddChatListData(string userName, string message)
        {
            var chatUserIconUrl = _twitchApiController.GetTwitchIconUrl(userName);
            ChatModel chatModel = new ChatModel { Name = userName, Chat = message, Icon = chatUserIconUrl };
            _chatDataQueue.Enqueue(chatModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnLog(object? sender, OnLogArgs e)
        {
            LogController.OutputLog($@"{e.BotUsername} - {e.Data}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnConnected(object? sender, OnConnectedArgs e)
        {
            LogController.OutputLog($@"Connected to {_twitchUserName}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnDisconnected(object? sender, OnDisconnectedEventArgs e)
        {
            LogController.OutputLog($"Disconnected to {_twitchUserName}");
        }

        /// <summary>
        /// Botを起動します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnJoinedChannel(object? sender, OnJoinedChannelArgs e)
        {
            SendMessage(e.Channel, "Login FaraBot.");
            LogController.OutputLog("Login FaraBot.");

            if (_secretKeys.BouyomiChan.Checked) SendMessage(e.Channel, "Connecting BouyomiChan.");
            else SendMessage(e.Channel, "Not connecting BouyomiChan.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void TwitchPubSubOnListen(OnListenResponseArgs e)
        {
            if (!_pubsubFailure && !e.Successful)
            {
                _pubsubFailure = true;
                var message = "Failed to connect to Twitch PubSub. Please renew your token and reconnect.";
                SendMessage(_twitchUserName, message);
                LogController.OutputLog($"{message} Exception: {e}");
            }
        }

        /// <summary>
        /// Followerが増えたときに実行されます。
        /// </summary>
        /// <param name="e"></param>
        public void TwitchPubSubOnFollow(OnFollowArgs e)
        {
            var followerChannelUrl = $"https://twitch.tv/{e.Username}";
            var followerName = e.DisplayName;
            var message = _secretKeys.Event.Follow.Message.Replace("{followerName}", followerName)
                .Replace("{followerChannelUrl}", followerChannelUrl);
            SendMessage(followerName, message);
            // 棒読みちゃん用の読み上げの言語設定あってもいいかも
            _bouyomiChanController.AddEventTalkTask($"{followerName}さんがFollowしました", _secretKeys.BouyomiChan.Checked);
            LogController.OutputLog($"<Follow> Name: {followerName}, URL: {followerChannelUrl}");
        }

        /// <summary>
        /// 別チャンネルからRaidが来たときに実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnRaidNotification(object? sender, OnRaidNotificationArgs e)
        {
            var raiderName = e.RaidNotification.MsgParamLogin;
            var raiderChannelUrl = $"https://twitch.tv/{raiderName}";
            var message = _secretKeys.Event.Raid.Message.Replace("{raiderName}", raiderName)
                .Replace("{raiderChannelUrl}", raiderChannelUrl);
            SendMessage(raiderName, message);
            _bouyomiChanController.AddEventTalkTask($"{raiderName}さんにRaidされました", _secretKeys.BouyomiChan.Checked);
            Task.Run(async () =>
            {
                await Task.Delay(10000);
                SendMessage(_twitchUserName, $"/shoutout {raiderName}");
            });
            LogController.OutputLog($"<Raid> Name: {raiderName}, URL: {raiderChannelUrl}");
        }

        /// <summary>
        /// 新規サブスク時に実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnNewSubscriber(object? sender, OnNewSubscriberArgs e)
        {
            var subscriberName = e.Subscriber.DisplayName;
            var message = _secretKeys.Event.Subscription.Message.Replace("{subscriberName}", subscriberName)
                .Replace("{totalSubscriptionMonth}", "1");
            SendMessage(subscriberName, message);
            _bouyomiChanController.AddEventTalkTask($"{subscriberName}さん新規サブスクありがとうございます", _secretKeys.BouyomiChan.Checked);
            LogController.OutputLog($"<New Subscriber> Name: {subscriberName}");
        }

        /// <summary>
        /// 継続サブスク時に実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnReSubscriber(object? sender, OnReSubscriberArgs e)
        {
            var subscriberName = e.ReSubscriber.DisplayName;
            var totalSubscriptionMonth = e.ReSubscriber.Months;
            var message = _secretKeys.Event.Subscription.Message.Replace("{subscriberName}", subscriberName)
                .Replace("{totalSubscriptionMonth}", totalSubscriptionMonth.ToString());
            SendMessage(subscriberName, message);
            _bouyomiChanController.AddEventTalkTask($"{subscriberName}さん{totalSubscriptionMonth}か月目のサブスクありがとうございます", _secretKeys.BouyomiChan.Checked);
            LogController.OutputLog($"<Subscriber> Name: {subscriberName}, total: {totalSubscriptionMonth} time.");
        }

        /// <summary>
        /// Bitsを受け取った時に実行されます。
        /// </summary>
        /// <param name="e"></param>
        public void SendBitsPubSubMessage(OnBitsReceivedV2Args e)
        {
            var bitsSendUserName = e.UserName;
            var bitsAmount = e.BitsUsed;
            var totalBitsAmount = e.TotalBitsUsed;
            var bitsReceivedChannelUrl = $"https://twitch.tv/{bitsSendUserName}";
            var message = _secretKeys.Event.Bits.Message.Replace("{bitsAmount}", bitsAmount.ToString())
                .Replace("{totalBitsAmount}", totalBitsAmount.ToString())
                .Replace("{bitsSendUserName}", bitsSendUserName);
            SendMessage(bitsSendUserName, message);
            _bouyomiChanController.AddEventTalkTask($"{bitsSendUserName}さん{bitsAmount}bitsありがとうございます", _secretKeys.BouyomiChan.Checked);
            LogController.OutputLog(
                $"<Bits> UserName: {bitsSendUserName}, Amount: {bitsAmount}, Total: {totalBitsAmount}");
        }

        /// <summary>
        /// サブスクを受け取った時に実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnGiftedSubscription(object? sender, OnGiftedSubscriptionArgs e)
        {
            var giftedUserName = e.GiftedSubscription.DisplayName;
            var url = $"https://twitch.tv/{giftedUserName}";
            var message = _secretKeys.Event.Gift.Message.Replace("{giftedUserName}", giftedUserName);
            SendMessage(giftedUserName, message);
            _bouyomiChanController.AddEventTalkTask($"{giftedUserName}さんGiftありがとうございます", _secretKeys.BouyomiChan.Checked);
            LogController.OutputLog($"<Gift> Name: {giftedUserName} URL: {url}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void SendChannelPointPubSubMessage(OnChannelPointsRewardRedeemedArgs e)
        {
            var channelPointTitle = e.RewardRedeemed.Redemption.Reward.Title;
            var channelPointUserName = e.RewardRedeemed.Redemption.User.DisplayName;
            var channelPointCost = e.RewardRedeemed.Redemption.Reward.Cost;
            var message = _secretKeys.Event.ChannelPoint.Message
                .Replace("{channelPointCost}", channelPointCost.ToString())
                .Replace("{channelPointTitle}", channelPointTitle)
                .Replace("{channelPointUserName}", channelPointUserName);
            SendMessage(channelPointUserName, message);
            _bouyomiChanController.AddEventTalkTask($"{channelPointUserName}さんが{channelPointCost}ChannelPointで{channelPointTitle}を使用しました", _secretKeys.BouyomiChan.Checked);
            LogController.OutputLog($"<ChannelPoint> UserName: {channelPointUserName}, Title: {channelPointTitle}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void SendPredictionPubSubMessage(OnPredictionArgs e)
        {
            // Predictionは最終結果がどれか取得できないので無視
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnMessageReceived(object? sender, OnMessageReceivedArgs e)
        {
            // Twitchチャット上のコメントのみ受け取れる
            if (e.ChatMessage.Message.Contains(@"badword"))
                _twitchClient.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30),
                    "Bad word! 30 minute timeout!");
            try
            {
                SendMessageTranslation(e);
            }
            catch (Exception ex)
            {
                LogController.OutputLog(e.ChatMessage.Message);
                LogController.OutputLog(ex.Message, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private async void SendMessageTranslation(OnMessageReceivedArgs e)
        {
            var userName = e.ChatMessage.Username;
            var displayName = e.ChatMessage.DisplayName;
            var sourceMessage = e.ChatMessage.Message;
            // 翻訳済み文字は再翻訳しない
            if (sourceMessage.Contains("[FaraBot]")) return;

            var beatSaberRegexMessage = TextRegexController.LoadBsrChat(sourceMessage);
            if (sourceMessage != beatSaberRegexMessage)
            {
                // bsrリクエストの時は読み上げ
                if (sourceMessage.Contains("!bsr")) 
                    _bouyomiChanController.AddTalkTask(userName, beatSaberRegexMessage, _secretKeys.BouyomiChan.Checked);

                return;
            }

            try
            {
                var targetLanguage = !IsJapaneseLanguage(sourceMessage) ? LanguageCode.Japanese : LanguageCode.EnglishAmerican;
                var text = await _deepLTranslator.TranslateTextAsync(sourceMessage, null, targetLanguage);
                var sourceLanguage = text.DetectedSourceLanguageCode;
                var translateMessage = text.Text;
                SendMessage(userName, $"[FaraBot {sourceLanguage}->{targetLanguage}] {translateMessage} (by {displayName})");

                if (_secretKeys.BouyomiChan.Checked)
                {
                    // 母国語で読み上げ
                    // Song Request Manager用の読み上げ変換をしたい
                    var message = sourceLanguage == LanguageCode.Japanese ? sourceMessage : translateMessage;
                    _bouyomiChanController.AddTalkTask(displayName, message, _secretKeys.BouyomiChan.Checked);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = "DeepL翻訳に失敗しています。詳しくはログを確認してください。";
                SendMessage(displayName, $"[FaraBot] @{_twitchClient.TwitchUsername} {errorMessage}");
                if (_secretKeys.BouyomiChan.Checked)
                {
                    _bouyomiChanController.AddTalkTask(_twitchClient.TwitchUsername, errorMessage, _secretKeys.BouyomiChan.Checked);
                }

                LogController.OutputLog(ex.Message, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Usage> DeepLUsage()
        {
            // 定期的に文字数取得してグラフ表示
            // https://blog.hiros-dot.net/?p=2123
            return await _deepLTranslator.GetUsageAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool IsJapaneseLanguage(string message)
        {
            if (!Regex.IsMatch(message, @"^[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+"))
            {
                return false;
            }

            // fix 中国語が日本語判定されるけど、今はそんなユーザーいないので後で直す
            // https://qiita.com/Saqoosha/items/927e9d6e77922ad9f08a
            return true;
        }
    }
}