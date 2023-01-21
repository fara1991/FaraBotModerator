﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaraBotModerator.Controller;
using FaraBotModerator.Model;
using FaraBotModerator.Properties;
using Microsoft.Web.WebView2.WinForms;

namespace FaraBotModerator
{
    public partial class FaraBotModeratorForm : Form
    {
        private TwitchClientController _twitchClientController;
        private TwitchApiController _twitchApiController;
        private TwitchPubSubController _twitchPubSubController;
        private TwitterController _twitterController;
        private Form _authorizeTokenForm;
        private WebView2 _authorizeTokenWebView;
        private bool _authorizeButtonPushed;

        public FaraBotModeratorForm()
        {
            InitializeComponent();
            InitializeSecretValue();
            InitializeTokenForm();
            InitializeWebServer();
        }

        private void InitializeSecretValue()
        {
            var secretKeys = SecretKeyController.LoadKeys();
            if (secretKeys != null)
            {
                TwitchClientUserNameTextBox.Text = secretKeys.Twitch.Client.UserName;
                TwitchClientAccessTokenTextBox.Text = secretKeys.Twitch.Client.AccessToken;
                
                TwitchApiClientIdTextBox.Text = secretKeys.Twitch.Api.ClientId;
                TwitchApiClientSecretTextBox.Text = secretKeys.Twitch.Api.Secret;

                DeepLAPIFreeAuthKeyTextBox.Text = secretKeys.DeepL.FreeAuthKey;
                DeepLAPIProAuthKeyTextBox.Text = secretKeys.DeepL.ProAuthKey;
                
                TwitterAPIKeyTextBox.Text = secretKeys.Twitter.ApiKey;
                TwitterAPISecretTextBox.Text = secretKeys.Twitter.ApiSecret;

                BouyomiChanConnectCheckBox.Checked = secretKeys.BouyomiChan.Checked;
                
                FollowCheckBox.Checked = secretKeys.Event.Follow.Checked;
                FollowEventTextBox.Text = secretKeys.Event.Follow.Message;

                RaidCheckBox.Checked = secretKeys.Event.Raid.Checked;
                RaidEventTextBox.Text = secretKeys.Event.Raid.Message;

                SubscriptionCheckBox.Checked = secretKeys.Event.Subscription.Checked;
                SubscriptionEventTextBox.Text = secretKeys.Event.Subscription.Message;

                BitsCheckBox.Checked = secretKeys.Event.Bits.Checked;
                BitsEventTextBox.Text = secretKeys.Event.Bits.Message;

                GiftCheckBox.Checked = secretKeys.Event.Gift.Checked;
                GiftEventTextBox.Text = secretKeys.Event.Gift.Message;

                ChannelPointCheckBox.Checked = secretKeys.Event.ChannelPoint.Checked;
                ChannelPointEventTextBox.Text = secretKeys.Event.ChannelPoint.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeTokenForm()
        {
            _authorizeTokenWebView = new WebView2();
            _authorizeTokenWebView.Name = "TwitchApiTokenWebView";
            _authorizeTokenWebView.Size = new Size(640, 640);
            _authorizeTokenWebView.Location = new Point(365, 6);

            _authorizeTokenForm = new Form();
            _authorizeTokenForm.ControlBox = false;
            var resources = new ComponentResourceManager(typeof(FaraBotModeratorForm));
            _authorizeTokenForm.Icon = (Icon) resources.GetObject("$this.Icon");
            _authorizeTokenForm.Text = @"Authentication Token Browser";
            _authorizeTokenForm.Controls.Add(_authorizeTokenWebView);
            _authorizeTokenForm.Hide();
        }

        private async Task InitializeWebServer()
        {
            await _authorizeTokenWebView.EnsureCoreWebView2Async(null);
            while (true)
            {
                await Task.Delay(1);
                var url = _authorizeTokenWebView.CoreWebView2.Source;
                if (!_authorizeButtonPushed || !url.Contains("code="))
                {
                    continue;
                }

                _authorizeButtonPushed = false;

                UpdateAccessToken(url);
                HideWebView();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        /// Token期限切れの時に呼び出してTokenを更新します。
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        private void UpdateRefreshToken()
        {
            var parameter =
                $"client_id={TwitchApiClientIdTextBox.Text}" +
                $"&client_secret={TwitchApiClientSecretTextBox.Text}" +
                "&grant_type=refresh_token" +
                $"&refresh_token={Settings.Default.RefreshToken}";
            var response = Task.Run(() =>
                PostResponseBodyAsync(parameter, "https://id.twitch.tv/oauth2/token")
            ).Result;

            if (response.responseBody.Contains("error"))
            {
                LogController.OutputLog(
                    "Unauthenticated. Please check [https://dev.twitch.tv/console] Application redirectURL, clientID, and secret.");
                throw new HttpRequestException(
                    "Unauthenticated. Please check [https://dev.twitch.tv/console] Application redirectURL, clientID, and secret.");
            }

            var jsonString =
                JsonSerializer.Deserialize<TwitchRefreshTokenModel>(response.responseBody, response.option);
            Settings.Default.AccessToken = jsonString?.AccessToken;
            Settings.Default.RefreshToken = jsonString?.RefreshToken;
            Settings.Default.Save();
        }

        /// <summary>
        /// Twitch API Access Tokenを取得、更新します。
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="HttpRequestException"></exception>
        private void UpdateAccessToken(string url)
        {
            var code = Regex.Match(url, @"code=(.*?)&.*?").Groups[1];
            var parameter =
                $"client_id={TwitchApiClientIdTextBox.Text}" +
                $"&client_secret={TwitchApiClientSecretTextBox.Text}" +
                $"&code={code}" +
                "&grant_type=authorization_code" +
                $"&redirect_uri=http://localhost:{Settings.Default.Port}";
            var response = Task.Run(() => PostResponseBodyAsync(parameter, "https://id.twitch.tv/oauth2/token")).Result;
            if (response.responseBody.Contains("Invalid authorization code"))
            {
                LogController.OutputLog(
                    "Unauthenticated. Please check [https://dev.twitch.tv/console] Application redirectURL, clientID, and secret.");
                throw new HttpRequestException(
                    "Unauthenticated. Please check [https://dev.twitch.tv/console] Application redirectURL, clientID, and secret.");
            }

            var jsonString =
                JsonSerializer.Deserialize<TwitchOAuthTokenModel>(response.responseBody, response.option);
            Settings.Default.AccessToken = jsonString?.AccessToken;
            Settings.Default.RefreshToken = jsonString?.RefreshToken;
            if (jsonString?.ExpiresIn != null)
            {
                var datetime = DateTime.Now;
                Settings.Default.ExpirationDate = datetime.AddSeconds(jsonString.ExpiresIn);
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// 指定URLに対してPost Requestを送信します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<(string responseBody, JsonSerializerOptions option)> PostResponseBodyAsync(string parameter,
            string url)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(parameter, Encoding.Default, "application/x-www-form-urlencoded");
                var response = await httpClient.PostAsync(url, content);

                var responseBody = response.Content.ReadAsStringAsync().Result;
                var option = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                return (responseBody, option);
            }
        }

        /// <summary>
        /// 指定URLのページをWebViewで表示します。
        /// </summary>
        /// <param name="requestUrl"></param>
        private void ShowWebView(string requestUrl)
        {
            // Button押した瞬間だけフラグ変更。InitializeWebServer()内で押した瞬間を判定
            _authorizeButtonPushed = true;
            _authorizeTokenForm.Show(this);
            TwitchClientAccessTokenButton.Enabled = false;
            TwitchApiAuthorizeButton.Enabled = false;
            TwitchConnectionButton.Enabled = false;
            TwitchDisconnectButton.Enabled = false;
            TwitterApiButton.Enabled = false;
            TwitterPushTweetButton.Enabled = false;
            TwitterConnectionButton.Enabled = false;
            TwitterDisconnectionButton.Enabled = false;
            MenuTab.Enabled = false;
            _authorizeTokenWebView.CoreWebView2.Navigate(requestUrl);
        }

        /// <summary>
        /// WebViewを非表示にします。
        /// </summary>
        private void HideWebView()
        {
            _authorizeButtonPushed = false;
            _authorizeTokenForm.Hide();
            TwitchClientAccessTokenButton.Enabled = true;
            TwitchApiAuthorizeButton.Enabled = true;
            TwitchConnectionButton.Enabled = true;
            TwitchDisconnectButton.Enabled = true;
            TwitterApiButton.Enabled = true;
            TwitterPushTweetButton.Enabled = true;
            TwitterConnectionButton.Enabled = true;
            TwitterDisconnectionButton.Enabled = true;
            MenuTab.Enabled = true;
        }

        /// <summary>
        /// Secretの値を保存します。
        /// </summary>
        private void SaveSecretValue()
        {
            var secretKeys = new SecretKeyModel
            {
                Twitch = new TwitchSecretKeyModel
                {
                    Client = new TwitchClientKeyModel
                    {
                        UserName = TwitchClientUserNameTextBox.Text, // TwitchのURLの末尾の名前
                        AccessToken = TwitchClientAccessTokenTextBox.Text,
                    },
                    Api = new TwitchApiKeyModel
                    {
                        ClientId = TwitchApiClientIdTextBox.Text,
                        Secret = TwitchApiClientSecretTextBox.Text
                    }
                },
                Twitter = new TwitterKeyModel
                {
                    ApiKey = TwitterAPIKeyTextBox.Text,
                    ApiSecret = TwitterAPISecretTextBox.Text
                },
                DeepL = new DeepLKeyModel
                {
                    FreeAuthKey = DeepLAPIFreeAuthKeyTextBox.Text,
                    ProAuthKey = DeepLAPIProAuthKeyTextBox.Text
                },
                BouyomiChan = new BouyomiChanKeyModel
                {
                    Checked = BouyomiChanConnectCheckBox.Checked
                },
                Event = new ReactionEventModel
                {
                    Follow = new ReactionFollowEvent
                    {
                        Checked = FollowCheckBox.Checked,
                        Message = FollowEventTextBox.Text
                    },
                    Raid = new ReactionRaidEvent
                    {
                        Checked = RaidCheckBox.Checked,
                        Message = RaidEventTextBox.Text
                    },
                    Subscription = new ReactionSubscriptionEvent
                    {
                        Checked = SubscriptionCheckBox.Checked,
                        Message = SubscriptionEventTextBox.Text
                    },
                    Bits = new ReactionBitsEvent
                    {
                        Checked = BitsCheckBox.Checked,
                        Message = BitsEventTextBox.Text
                    },
                    Gift = new ReactionGiftEvent
                    {
                        Checked = GiftCheckBox.Checked,
                        Message = GiftEventTextBox.Text
                    },
                    ChannelPoint = new ReactionChannelPointEvent
                    {
                        Checked = ChannelPointCheckBox.Checked,
                        Message = ChannelPointEventTextBox.Text
                    }
                }
            };
            SecretKeyController.SaveKeys(secretKeys);
        }

        private void TwitchConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                _twitchClientController = new TwitchClientController(
                    TwitchClientUserNameTextBox.Text,
                    TwitchClientAccessTokenTextBox.Text,
                    FollowEventTextBox.Text,
                    RaidEventTextBox.Text,
                    SubscriptionEventTextBox.Text,
                    BitsEventTextBox.Text, 
                    GiftEventTextBox.Text,
                    ChannelPointEventTextBox.Text,
                    BouyomiChanConnectCheckBox.Checked
                    );
                _twitchClientController.Connect();

                _twitchApiController = new TwitchApiController(TwitchApiClientIdTextBox.Text,
                    TwitchApiClientSecretTextBox.Text, TwitchClientUserNameTextBox.Text);

                var channelId = _twitchApiController.GetTwitchChannelId();

                _twitchPubSubController = new TwitchPubSubController(_twitchClientController, channelId);
                _twitchPubSubController.Connect();
                TwitchConnectionStateLabel.Text = @"State: Connect";
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }

        private void TwitchDisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                _twitchClientController.Disconnect();
                _twitchPubSubController.DisConnect();
                TwitchConnectionStateLabel.Text = @"State: Disconnect";
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }

        private void TwitterConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                _twitterController = new TwitterController();
                _twitterController.SessionStart();
                TwitterConnectionStateLabel.Text = @"State: Connect";
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }

        private void TwitterDisconnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                TwitterConnectionStateLabel.Text = @"State: Disconnect";
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }

        private void TwitterPushTweetButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 文字が入って入れば
                // _twitterController.PushTweet(TwitterSendRichTextBox.Text);
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }

        private void TwitchAccessTokenButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://twitchapps.com/tmi/");
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }

        private void FollowTestButton_Click(object sender, EventArgs e)
        {
            // _twitchClientController
        }

        private void TwitterApiButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://developer.twitter.com/en/portal/dashboard");
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }

        private void FaraBotModeratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSecretValue();
        }

        private void TwitchApiAuthorizeButton_Click(object sender, EventArgs e)
        {
            //refreshTokenはaccessToken期限切れなら設定
            var requestUrl =
                "https://id.twitch.tv/oauth2/authorize" +
                $"?client_id={TwitchApiClientIdTextBox.Text}" +
                $"&redirect_uri=http://localhost%3A{Settings.Default.Port}" +
                "&response_type=code" +
                "&scope=bits%3Aread " + // bitsリーダーボード表示
                "channel%3Amanage%3Amoderators " + // moderator追加、削除
                "channel%3Amanage%3Apolls " + // アンケート作成
                "channel%3Amanage%3Apredictions " + // prediction作成、終了
                "channel%3Amanage%3Araids " + // raid開始、キャンセル
                "channel%3amanage%3Aredemptions " + // チャンネルポイント管理
                "channel%3Amanage%3Aschedule " + // スケジュール管理
                "channel%3Aread%3Ahype_train " + // ハイプトレイン取得
                "channel%3Aread%3Apolls " + // アンケート表示
                "channel%3Aread%3Apredictions " + // predictions取得
                "channel%3Aread%3Aredemptions " + // チャンネルポイント一覧
                "channel%3Aread%3Astream_key " + // ストリームキー表示
                "channel%3Aread%3Asubscriptions " + // SubScription一覧表示
                "channel%3Aread%3Avips " + // Vipメンバー一覧表示
                "channel%3Amanage%3Avips " + // Vipメンバー追加、削除
                "moderation%3Aread " + // Moderators, Bans, Timeouts, Automod設定
                "moderator%3Amanage%3Aannouncements " + // Moderator権限者によるannouncementコマンド実行
                "user%3Aedit " + // user編集
                "user%3Aread%3Abroadcast " + // broadcast設定取得
                "user%3Aread%3Afollows " + // follower取得
                "user%3Aread%3Asubscriptions " + // SubScriptionメンバー一覧取得
                "user%3Amanage%3Awhispers " + // whisper送信、受信
                "channel%3Amoderate " + // Moderator権限実行
                "chat%3Aedit " + // Chat送信
                "chat%3Aread " + // Chat受信
                "whispers:read " + // Whisper受信
                "whispers%3Aedit" + // Whisper送信
                "&state=c3ab8aa609ea11e793ae92361f002671";
            try
            {
                ShowWebView(requestUrl);
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }
    }
}