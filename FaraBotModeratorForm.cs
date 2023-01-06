using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaraBotModerator.Controller;
using FaraBotModerator.Model;
using FaraBotModerator.Properties;

namespace FaraBotModerator
{
    public partial class FaraBotModeratorForm : Form
    {
        private TwitchClientController _twitchClientController;
        private TwitchApiController _twitchApiController;
        private TwitchPubSubController _twitchPubSubController;
        private TwitterController _twitterController;
        private string _twitchApiAccessToken;
        private bool _authorizeButtonPushed;

        public FaraBotModeratorForm()
        {
            InitializeComponent();
            LoadSecretValue();
            InitializeWebServer();
        }

        private void LoadSecretValue()
        {
            var secretKeys = SecretKeyController.LoadKeys();
            TwitchClientUserNameTextBox.Text = secretKeys?.Twitch.Client.UserName;
            TwitchClientAccessTokenTextBox.Text = secretKeys?.Twitch.Client.AccessToken;
            TwitchClientChannelNameTextBox.Text = secretKeys?.Twitch.Client.ChannelName;
            TwitchApiClientIdTextBox.Text = secretKeys?.Twitch.Api.ClientId;
            TwitchApiSecretTextBox.Text = secretKeys?.Twitch.Api.Secret;
            // TwitchPubSubAccessTokenTextBox.Text = secretKeys?.Twitch.PubSub.AccessToken;
            // TwitchPubSubRefreshTokenTextBox.Text = secretKeys?.Twitch.PubSub.RefreshToken;
            TwitterAPIKeyTextBox.Text = secretKeys?.Twitter.ApiKey;
            TwitterAPISecretTextBox.Text = secretKeys?.Twitter.ApiSecret;
            DeepLAPIFreeAuthKeyTextBox.Text = secretKeys?.DeepL.FreeAuthKey;
            DeepLAPIProAuthKeyTextBox.Text = secretKeys?.DeepL.ProAuthKey;
        }

        private void SaveSecretValue()
        {
            var secretKeys = new SecretKeyModel
            {
                Twitch = new TwitchSecretKeyModel
                {
                    Client = new TwitchClientKeyModel
                    {
                        UserName = TwitchClientUserNameTextBox.Text,
                        AccessToken = TwitchClientAccessTokenTextBox.Text,
                        ChannelName = TwitchClientChannelNameTextBox.Text
                    },
                    Api = new TwitchApiKeyModel
                    {
                        ClientId = TwitchApiClientIdTextBox.Text,
                        Secret = TwitchApiSecretTextBox.Text
                        // },
                        // PubSub = new TwitchPubSubKeyModel
                        // {
                        // AccessToken = TwitchPubSubAccessTokenTextBox.Text,
                        // RefreshToken = TwitchPubSubRefreshTokenTextBox.Text
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
                }
            };
            SecretKeyController.SaveKeys(secretKeys);
        }

        private async Task InitializeWebServer()
        {
            await TwitchApiTokenWebView.EnsureCoreWebView2Async(null);
            WebViewGoSite("https://google.com");
            // var server = new HttpListener();
            // var localUrl = $"http://localhost:{Settings.Default.Port}/";
            // server.Prefixes.Clear();
            // server.Prefixes.Add(localUrl);
            // server.Start();
            var directory = Directory.GetCurrentDirectory() + "\\Web";
            var file = directory + "\\index.html";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(file))
            {
                File.Create(file);
            }

            while (true)
            {
                await Task.Delay(1);
                var url = TwitchApiTokenWebView.CoreWebView2.Source;
                if (!_authorizeButtonPushed || !url.Contains("code="))
                {
                    continue;
                }

                _authorizeButtonPushed = false;
                var code = Regex.Match(url, @"code=(.*?)&.*?").Groups[1];
                // TODO 取得したコード使ってaccessToken要求する(あとで)
                // WebViewをAppで表示する必要ないのでnew作成→終わったら削除でいいかも

            }
        }

        private void WebViewGoSite(string url)
        {
            // ブラウザではなくWebViewを開く
            // WebViewのURLを設定し、レスポンスで返ってきたURLからCodeを取得したい
            TwitchApiTokenWebView.CoreWebView2.Navigate(url);
        }

        private void TwitchConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                _twitchClientController = new TwitchClientController(TwitchClientUserNameTextBox.Text,
                    TwitchClientAccessTokenTextBox.Text,
                    TwitchClientChannelNameTextBox.Text, FollowEventTextBox.Text, RaidEventTextBox.Text,
                    SubscriptionEventTextBox.Text,
                    BitsEventTextBox.Text, GiftEventTextBox.Text, BouyomiChanConnectCheckBox.Checked);
                _twitchClientController.Connect();

                _twitchApiController = new TwitchApiController(_twitchClientController, TwitchApiClientIdTextBox.Text,
                    TwitchApiSecretTextBox.Text, TwitchClientUserNameTextBox.Text);

                var channelId = _twitchApiController.GetTwitchChannelId();

                _twitchPubSubController = new TwitchPubSubController(_twitchClientController, channelId, "",
                    TwitchApiClientIdTextBox.Text, TwitchApiSecretTextBox.Text);
                _twitchPubSubController.Connect();
                TwitchConnectionStateLabel.Text = @"State: Connect";
            }
            catch (Exception ex)
            {
                // 接続失敗したらアプリ左下に表示したい
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
            // var authToken = _twitchApiController.GetTwitchOauthToken();
            // var accessToken = authToken.AccessToken;
            // var refreshToken = authToken.RefreshToken;
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
                _authorizeButtonPushed = true;
                WebViewGoSite(requestUrl);
            }
            catch (Exception ex)
            {
                LogController.OutputLog(ex.Message);
            }
        }
    }
}