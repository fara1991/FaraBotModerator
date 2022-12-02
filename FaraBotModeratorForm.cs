using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FaraBotModerator.Controller;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FaraBotModerator.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FaraBotModerator
{
    public partial class FaraBotModeratorForm : Form
    {
        private TwitchClientController _twitchClientController;
        private TwitchApiController _twitchApiController;
        private TwitchPubSubController _twitchPubSubController;
        private TwitterController _twitterController;

        // Secret Keys
        private string _twitchUserName;
        private string _twitchAccessToken;
        private string _twitchChannelName;
        private string _twitchApiClientId;
        private string _twitchApiSecret;
        private string _twitchPubSubAccessToken;
        private string _twitchPubSubRefreshToken;
        private string _twitterApiKey;
        private string _twitterApiSecret;
        private string _deeplApiFreeAuthKey;
        private string _deeplApiProAuthKey;

        public FaraBotModeratorForm()
        {
            InitializeComponent();
            LoadSecretValue();
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

        private void TwitchConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                _twitchClientController = new TwitchClientController(_twitchUserName, _twitchAccessToken,
                    _twitchChannelName, FollowEventTextBox.Text, RaidEventTextBox.Text, SubscriptionEventTextBox.Text,
                    BitsEventTextBox.Text, GiftEventTextBox.Text, BouyomiChanConnectCheckBox.Checked);
                _twitchClientController.Connect();

                _twitchApiController = new TwitchApiController(_twitchClientController, _twitchApiClientId,
                    _twitchApiSecret, TwitchClientUserNameTextBox.Text);
                var channelId = _twitchApiController.GetTwitchChannelId();

                _twitchPubSubController = new TwitchPubSubController(_twitchClientController, channelId,
                    _twitchApiClientId, _twitchApiSecret);
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
    }
}