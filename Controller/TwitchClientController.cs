﻿using System;
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
using TwitchLib.PubSub.Events;
using OnLogArgs = TwitchLib.Client.Events.OnLogArgs;

namespace FaraBotModerator.Controller
{
    public class TwitchClientController
    {
        private readonly TwitchClient _twitchClient;
        private readonly BouyomiChanColtroller _bouyomiChanColtroller;
        private readonly string _userName;
        private readonly string _followedDisplayText;
        private readonly string _raidDisplayText;
        private readonly string _subscriptionDisplayText;
        private readonly string _bitsDisplayText;
        private readonly string _giftDisplayText;
        private readonly bool _isBouyomiChanConnect;

        public TwitchClientController(string userName, string accessToken, string channelName,
            string followedDisplayText, string raidDisplayText, string subscriptionDisplayText, string bitsDisplayText,
            string giftDisplayText, bool isBouyomiChanConnect)
        {
            _userName = userName;
            ConnectionCredentials credentials = new ConnectionCredentials(userName, accessToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            var customClient = new WebSocketClient(clientOptions);
            _twitchClient = new TwitchClient(customClient);
            _twitchClient.Initialize(credentials, channelName);

            _twitchClient.OnLog += TwitchClientOnLog;
            _twitchClient.OnJoinedChannel += TwitchClientOnJoinedChannel;
            _twitchClient.OnMessageReceived += TwitchClientOnMessageReceived;
            _twitchClient.OnNewSubscriber += TwitchClientOnNewSubscriber;
            _twitchClient.OnGiftedSubscription += TwitchClientOnGiftedSubscription;
            _twitchClient.OnRaidNotification += TwitchClientOnRaidNotification;
            _twitchClient.OnConnected += TwitchClientOnConnected;
            _twitchClient.OnDisconnected += TwitchClientOnDisconnected;
            _bouyomiChanColtroller = new BouyomiChanColtroller();

            _followedDisplayText = followedDisplayText;
            _raidDisplayText = raidDisplayText;
            _subscriptionDisplayText = subscriptionDisplayText;
            _bitsDisplayText = bitsDisplayText;
            _giftDisplayText = giftDisplayText;
            _isBouyomiChanConnect = isBouyomiChanConnect;
        }

        public void Connect()
        {
            _twitchClient.Connect();
        }

        public void Disconnect()
        {
            _twitchClient.Disconnect();
            _bouyomiChanColtroller.Dispose();
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
            _twitchClient.SendMessage(_userName, "Logout FaraBot");
            LogController.OutputLog("Logout FaraBot");
        }

        /// <summary>
        /// Botを起動します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            _twitchClient.SendMessage(_userName, "Login FaraBot");
            LogController.OutputLog("Login FaraBot.");
        }

        /// <summary>
        /// Followerが増えたときに実行されます。
        /// </summary>
        /// <param name="e"></param>
        public void SendFollowPubSubMessage(OnFollowArgs e)
        {
            
            var followerChannelUrl = $"https://twitch.tv/{e.Username}";
            var followerName = e.DisplayName;
            var message = _followedDisplayText.Replace("{followerName}", followerName)
                .Replace("{followerChannelUrl}", followerChannelUrl);
            _twitchClient.SendMessage(_twitchClient.TwitchUsername, message);
            LogController.OutputLog($"<Follow> Name: {followerName}, URL: {followerChannelUrl}");
        }

        /// <summary>
        /// Bitsを受け取った時に実行されます。
        /// </summary>
        /// <param name="e"></param>
        public void SendBitsPubSubMessage(OnBitsReceivedV2Args e)
        {
            var channel = _twitchClient.TwitchUsername;
            var bitsSendUserName = e.UserName;
            var bitsAmount = e.BitsUsed;
            var totalBitsAmount = e.TotalBitsUsed;
            var bitsReceivedChannelUrl = $"https://twitch.tv/{bitsSendUserName}";
            var message = _bitsDisplayText.Replace("{bitsAmount}", bitsAmount.ToString())
                .Replace("{totalBitsAmount}", totalBitsAmount.ToString())
                .Replace("{bitsSendUserName}", bitsSendUserName);
            _twitchClient.SendMessage(channel, message);
            LogController.OutputLog($"<Bits> Name: {bitsSendUserName}, URL: {bitsReceivedChannelUrl}");
        }

        public void SendPrepareRaidPubSubMessage(OnRaidUpdateV2Args e)
        {
            var channel = _twitchClient.TwitchUsername;
            var targetUserName = e.TargetLogin;
            // var message = ここにアプリのテキスト読み込み
        }
        
        public void SendRaidGoPubSubMessage(OnRaidGoArgs e)
        {
            var channel = e.TargetChannelId;
            var name = e.TargetDisplayName;
            var a = e.TargetProfileImage;
            var b = e.ChannelId;
        }
        
        /// <summary>
        /// 新規サブスクが増えたときに実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            var channel = e.Channel;
            var subscriberName = e.Subscriber.DisplayName;
            var url = $"https://twitch.tv/{subscriberName}";
            var message = _subscriptionDisplayText.Replace("{subscriberName}", subscriberName);
            _twitchClient.SendMessage(channel, message);
            LogController.OutputLog($"<Subscriber> Name: {subscriberName} URL: {url}");
        }

        /// <summary>
        /// サブスクを受け取った時に実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            var channel = e.Channel;
            var giftedUserName = e.GiftedSubscription.DisplayName;
            var url = $"https://twitch.tv/{giftedUserName}";
            var message = _giftDisplayText.Replace("{giftedUserName}", giftedUserName);
            _twitchClient.SendMessage(channel, message);
            LogController.OutputLog($"<Gift> Name: {giftedUserName} URL: {url}");
        }

        /// <summary>
        /// 別チャンネルからRaidが来たときに実行されます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchClientOnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            var channel = e.Channel;
            var raiderName = e.RaidNotification.MsgParamLogin;
            var url = $"https://twitch.tv/{raiderName}";
            var message = _raidDisplayText.Replace("{raiderName}", raiderName).Replace("{url}", url);
            _twitchClient.SendMessage(channel, message);
            LogController.OutputLog($"<Raid> Name: {raiderName}, URL: {url}");
        }

        private void TwitchClientOnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            // Twitchチャット上のコメントのみ受け取れる
            if (e.ChatMessage.Message.Contains(@"badword"))
                _twitchClient.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30),
                    "Bad word! 30 minute timeout!");
            try
            {
                var channel = e.ChatMessage.Channel;
                var message = e.ChatMessage.Message;
                var displayName = e.ChatMessage.DisplayName;
                SendMessageTranslation(channel, displayName, message);
            }
            catch (RemotingException ex)
            {
                _twitchClient.SendMessage(e.ChatMessage.Channel, e.ChatMessage.Message);
                LogController.OutputLog(e.ChatMessage.Message);
                LogController.OutputLog(ex.Message);
            }
            catch (Exception ex)
            {
                LogController.OutputLog(e.ChatMessage.Message);
                LogController.OutputLog(ex.Message);
            }
        }

        private async void SendMessageTranslation(string channel, string displayName, string sourceMessage)
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
                        _bouyomiChanColtroller.AddTalkTask(displayName, beatSaberRegexMessage);
                        return;
                    }

                    // 日本語以外は日本語に翻訳
                    var targetLanguage = !isJapaneseLanguage(sourceMessage) ? "JA" : "EN";
                    var jsonString = await DeepLTranslationResult(sourceMessage, targetLanguage, httpClient);
                    var sourceLanguage = jsonString?.Translations[0].Language;
                    var translateMessage = jsonString?.Translations[0].Text;
                    _twitchClient.SendMessage(channel,
                        $"[FaraBot {sourceLanguage}->{targetLanguage}] {translateMessage} (by {displayName})");

                    if (_isBouyomiChanConnect)
                    {
                        // 母国語で読み上げ
                        // Song Request Manager用の読み上げ変換をしたい
                        var message = sourceLanguage == "JA" ? sourceMessage : translateMessage;
                        _bouyomiChanColtroller.AddTalkTask(displayName, message);
                    }
                }
            }
            catch (RemotingException ex)
            {
                var errorMessage = "棒読みちゃんとの通信エラーが起きています。棒読みちゃんを再起動してください。";
                _twitchClient.SendMessage(channel, $"[FaraBot] @{_userName} {errorMessage}");
                LogController.OutputLog(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = "DeepL翻訳に失敗しています。詳しくはログを確認してください。";
                _twitchClient.SendMessage(channel, $"[FaraBot] @{_userName} {errorMessage}");
                if (_isBouyomiChanConnect)
                {
                    _bouyomiChanColtroller.AddTalkTask(_userName, errorMessage);
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

        private bool isJapaneseLanguage(string message)
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