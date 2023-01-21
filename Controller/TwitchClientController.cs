using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FaraBotModerator.Model;
using FNF.Utility;
using TwitchLib.Api.Helix.Models.Users.GetUsers;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;
using TwitchLib.PubSub.Enums;
using TwitchLib.PubSub.Events;
using OnLogArgs = TwitchLib.Client.Events.OnLogArgs;

namespace FaraBotModerator.Controller
{
    public class TwitchClientController
    {
        private readonly TwitchClient _twitchClient;
        private readonly BouyomiChanController _bouyomiChanController;
        private readonly bool _isBouyomiChanConnect;
        private readonly string _followedDisplayText;
        private readonly string _raidDisplayText;
        private readonly string _subscriptionDisplayText;
        private readonly string _bitsDisplayText;
        private readonly string _giftDisplayText;
        private readonly string _channelPointDisplayText;

        public TwitchClientController(string userName, string accessToken,
            string followedDisplayText, string raidDisplayText,
            string subscriptionDisplayText, string bitsDisplayText,
            string giftDisplayText, 
            string channelPointDisplayText,
            bool isBouyomiChanConnect)
        {
            ConnectionCredentials credentials = new ConnectionCredentials(userName, accessToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            var customClient = new WebSocketClient(clientOptions);
            _twitchClient = new TwitchClient(customClient);
            _twitchClient.Initialize(credentials, userName);

            _twitchClient.OnLog += TwitchClientOnLog;
            _twitchClient.OnJoinedChannel += TwitchClientOnJoinedChannel;
            _twitchClient.OnMessageReceived += TwitchClientOnMessageReceived;
            _twitchClient.OnNewSubscriber += TwitchClientOnNewSubscriber;
            _twitchClient.OnReSubscriber += TwitchClientOnReSubscriber;
            _twitchClient.OnGiftedSubscription += TwitchClientOnGiftedSubscription;
            _twitchClient.OnRaidNotification += TwitchClientOnRaidNotification;
            _twitchClient.OnConnected += TwitchClientOnConnected;
            _twitchClient.OnDisconnected += TwitchClientOnDisconnected;
            _bouyomiChanController = new BouyomiChanController();

            _followedDisplayText = followedDisplayText;
            _raidDisplayText = raidDisplayText;
            _subscriptionDisplayText = subscriptionDisplayText;
            _bitsDisplayText = bitsDisplayText;
            _giftDisplayText = giftDisplayText;
            _channelPointDisplayText = channelPointDisplayText;
            _isBouyomiChanConnect = isBouyomiChanConnect;
        }

        public void Connect()
        {
            _twitchClient.Connect();
        }

        public void Disconnect()
        {
            _twitchClient.Disconnect();
            _bouyomiChanController.Dispose();
        }

        private void SendMessage(string message)
        {
            _twitchClient.SendMessage(_twitchClient.TwitchUsername, message);
        }

        private void TwitchClientOnLog(object sender, OnLogArgs e)
        {
            LogController.OutputLog($@"{e.BotUsername} - {e.Data}");
        }

        private void TwitchClientOnConnected(object sender, OnConnectedArgs e)
        {
            LogController.OutputLog($@"Connected to {e.AutoJoinChannel}");
        }

        /// <summary>
        /// Botを停止します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            SendMessage("Logout FaraBot");
            LogController.OutputLog("Logout FaraBot");
        }

        /// <summary>
        /// Botを起動します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            SendMessage("Login FaraBot");
            LogController.OutputLog("Login FaraBot.");
        }

        /// <summary>
        /// Followerが増えたときに実行されます。
        /// </summary>
        /// <param name="e"></param>
        public void TwitchPubSubOnFollow(OnFollowArgs e)
        {
            var followerChannelUrl = $"https://twitch.tv/{e.Username}";
            var followerName = e.DisplayName;
            var message = _followedDisplayText.Replace("{followerName}", followerName)
                .Replace("{followerChannelUrl}", followerChannelUrl);
            SendMessage(message);
            LogController.OutputLog($"<Follow> Name: {followerName}, URL: {followerChannelUrl}");
        }

        /// <summary>
        /// 別チャンネルからRaidが来たときに実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            var raiderName = e.RaidNotification.MsgParamLogin;
            var raiderChannelUrl = $"https://twitch.tv/{raiderName}";
            var message = _raidDisplayText.Replace("{raiderName}", raiderName).Replace("{raiderChannelUrl}", raiderChannelUrl);
            SendMessage(message);
            LogController.OutputLog($"<Raid> Name: {raiderName}, URL: {raiderChannelUrl}");
        }

        /// <summary>
        /// 新規サブスク時に実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            var subscriberName = e.Subscriber.DisplayName;
            var message = _subscriptionDisplayText.Replace("{subscriberName}", subscriberName).Replace("{totalSubscriptionMonth}", "1");
            SendMessage(message);
            LogController.OutputLog($"<New Subscriber> Name: {subscriberName}");
        }

        /// <summary>
        /// 継続サブスク時に実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            var subscriberName = e.ReSubscriber.DisplayName;
            var totalSubscriptionMonth = e.ReSubscriber.Months;
            var message = _subscriptionDisplayText.Replace("{subscriberName}", subscriberName)
                .Replace("{totalSubscriptionMonth}", totalSubscriptionMonth.ToString());
            SendMessage(message);
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
            var message = _bitsDisplayText.Replace("{bitsAmount}", bitsAmount.ToString())
                .Replace("{totalBitsAmount}", totalBitsAmount.ToString())
                .Replace("{bitsSendUserName}", bitsSendUserName);
            SendMessage(message);
            LogController.OutputLog($"<Bits> UserName: {bitsSendUserName}, Amount: {bitsAmount}, Total: {totalBitsAmount}");
        }

        /// <summary>
        /// サブスクを受け取った時に実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            var giftedUserName = e.GiftedSubscription.DisplayName;
            var url = $"https://twitch.tv/{giftedUserName}";
            var message = _giftDisplayText.Replace("{giftedUserName}", giftedUserName);
            SendMessage(message);
            LogController.OutputLog($"<Gift> Name: {giftedUserName} URL: {url}");
        }

        public void SendChannelPointPubSubMessage(OnChannelPointsRewardRedeemedArgs e)
        {
            var channelPointTitle = e.RewardRedeemed.Redemption.Reward.Title;
            var channelPointUserName = e.RewardRedeemed.Redemption.User.DisplayName;
            var message = _channelPointDisplayText
                .Replace("{channelPointTitle}", channelPointTitle)
                .Replace("{channelPointUserName}", channelPointUserName);
            SendMessage(message);
            LogController.OutputLog($"<ChannelPoint> UserName: {channelPointUserName}, Title: {channelPointTitle}");
        }

        public void SendPredictionPubSubMessage(OnPredictionArgs e)
        {
            // Predictionは最終結果がどれか取得できないので無視
        }

        private void TwitchClientOnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            // Twitchチャット上のコメントのみ受け取れる
            if (e.ChatMessage.Message.Contains(@"badword"))
                _twitchClient.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30),
                    "Bad word! 30 minute timeout!");
            try
            {
                var displayName = e.ChatMessage.DisplayName;
                var message = e.ChatMessage.Message;
                SendMessageTranslation(displayName, message);
            }
            catch (RemotingException ex)
            {
                SendMessage(e.ChatMessage.Message);
                LogController.OutputLog(e.ChatMessage.Message);
                LogController.OutputLog(ex.Message);
            }
            catch (Exception ex)
            {
                LogController.OutputLog(e.ChatMessage.Message);
                LogController.OutputLog(ex.Message);
            }
        }

        private async void SendMessageTranslation(string displayName, string sourceMessage)
        {
            // 翻訳済み文字は再翻訳しない
            if (sourceMessage.Contains("[FaraBot]")) return;

            // !bsr のような特殊な文章は翻訳しないで棒読みちゃんだけ読み上げたい
            var textRegexModel = new TextRegexModel(sourceMessage);
            var beatSaberRegexMessage = textRegexModel.BeatSaberRegex();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (sourceMessage != beatSaberRegexMessage)
                    {
                        _bouyomiChanController.AddTalkTask(displayName, beatSaberRegexMessage);
                        return;
                    }

                    // 日本語以外は日本語に翻訳
                    var targetLanguage = !IsJapaneseLanguage(sourceMessage) ? "JA" : "EN";
                    var jsonString = await DeepLTranslationResult(sourceMessage, targetLanguage, httpClient);
                    var sourceLanguage = jsonString?.Translations[0].Language;
                    var translateMessage = jsonString?.Translations[0].Text;
                    SendMessage($"[FaraBot {sourceLanguage}->{targetLanguage}] {translateMessage} (by {displayName})");

                    if (_isBouyomiChanConnect)
                    {
                        // 母国語で読み上げ
                        // Song Request Manager用の読み上げ変換をしたい
                        var message = sourceLanguage == "JA" ? sourceMessage : translateMessage;
                        _bouyomiChanController.AddTalkTask(displayName, message);
                    }
                }
            }
            catch (RemotingException ex)
            {
                var errorMessage = "棒読みちゃんとの通信エラーが起きています。棒読みちゃんを再起動してください。";
                SendMessage($"[FaraBot] @{_twitchClient.TwitchUsername} {errorMessage}");
                LogController.OutputLog(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = "DeepL翻訳に失敗しています。詳しくはログを確認してください。";
                SendMessage($"[FaraBot] @{_twitchClient.TwitchUsername} {errorMessage}");
                if (_isBouyomiChanConnect)
                {
                    _bouyomiChanController.AddTalkTask(_twitchClient.TwitchUsername, errorMessage);
                }
                LogController.OutputLog(ex.Message);
            }
        }

        private static async Task<DeepLTranslationModel> DeepLTranslationResult(string sourceMessage,
            string targetLanguage, HttpClient httpClient)
        {
            var deepLAuthKey = ConfigurationManager.AppSettings.Get("DeepLAuthKey");
            var parameter = $"auth_key={deepLAuthKey}&text={sourceMessage}&target_lang={targetLanguage}";
            var content = new StringContent(parameter, Encoding.Default, "application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("https://api-free.deepl.com/v2/translate", content);
            var responseBody = response.Content.ReadAsStringAsync().Result;

            var option = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var jsonString =
                JsonSerializer.Deserialize<DeepLTranslationModel>(responseBody,
                    option);
            return jsonString;
        }

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