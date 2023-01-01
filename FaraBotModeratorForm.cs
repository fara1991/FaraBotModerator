﻿using System;
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
            Application.ApplicationExit += Application_Exit;
        }

        private void LoadSecretValue()
        {
            var secretKeys = SecretKeyController.LoadKeys();
            _twitchUserName = secretKeys?.Twitch.Client.UserName;
            _twitchAccessToken = secretKeys?.Twitch.Client.AccessToken;
            _twitchChannelName = secretKeys?.Twitch.Client.ChannelName;
            _twitchApiClientId = secretKeys?.Twitch.Api.ClientId;
            _twitchApiSecret = secretKeys?.Twitch.Api.Secret;
            _twitchPubSubAccessToken = secretKeys?.Twitch.PubSub.AccessToken;
            _twitchPubSubRefreshToken = secretKeys?.Twitch.PubSub.RefreshToken;
            _twitterApiKey = secretKeys?.Twitter.ApiKey;
            _twitterApiSecret = secretKeys?.Twitter.ApiSecret;
            _deeplApiFreeAuthKey = secretKeys?.DeepL.FreeAuthKey;
            _deeplApiProAuthKey = secretKeys?.DeepL.ProAuthKey;

            if (!string.IsNullOrEmpty(_twitchUserName))
            {
                TwitchUserNameTextBox.Text = _twitchUserName;
            }

            if (!string.IsNullOrEmpty(_twitchAccessToken))
            {
                TwitchAccessTokenTextBox.Text = _twitchAccessToken;
            }

            if (!string.IsNullOrEmpty(_twitchChannelName))
            {
                TwitchChannelNameLabel.Text = $@"ChannelName: {_twitchChannelName}";
            }

            if (!string.IsNullOrEmpty(_twitterApiKey))
            {
                TwitterAPIKeyTextBox.Text = _twitterApiKey;
            }

            if (!string.IsNullOrEmpty(_twitterApiSecret))
            {
                TwitterAPISecretTextBox.Text = _twitterApiSecret;
            }

            if (!string.IsNullOrEmpty(_deeplApiFreeAuthKey))
            {
                DeepLAPIFreeAuthKeyTextBox.Text = _deeplApiFreeAuthKey;
            }

            if (!string.IsNullOrEmpty(_deeplApiProAuthKey))
            {
                DeepLAPIProAuthKeyTextBox.Text = _deeplApiProAuthKey;
            }
        }

        private void SaveSecretValue()
        {
            var secretKeys = new SecretKeyModel
            {
                Twitch = new TwitchSecretKeyModel
                {
                    Client = new TwitchClientKeyModel
                    {
                        UserName = _twitchUserName, 
                        AccessToken = _twitchAccessToken,
                        ChannelName = _twitchChannelName
                    },
                    Api = new TwitchApiKeyModel
                    {
                        ClientId = _twitchApiClientId,
                        Secret = _twitchApiSecret
                    },
                    PubSub = new TwitchPubSubKeyModel
                    {
                        AccessToken = _twitchPubSubAccessToken,
                        RefreshToken = _twitchPubSubRefreshToken
                    }
                },
                Twitter = new TwitterKeyModel
                {
                    ApiKey = _twitterApiKey,
                    ApiSecret = _twitterApiSecret
                },
                DeepL = new DeepLKeyModel
                {
                    FreeAuthKey = _deeplApiFreeAuthKey,
                    ProAuthKey = _deeplApiProAuthKey
                }
            };

            SecretKeyController.SaveKeys(secretKeys);
        }

        private void TwitchConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                _twitchClientController = new TwitchClientController(_twitchUserName, _twitchAccessToken, _twitchChannelName, FollowEventTextBox.Text, RaidEventTextBox.Text, SubscriptionEventTextBox.Text, BitsEventTextBox.Text, GiftEventTextBox.Text, BouyomiChanConnectCheckBox.Checked);
                _twitchClientController.Connect();
                
                _twitchApiController = new TwitchApiController(_twitchClientController, _twitchApiClientId, _twitchApiSecret, TwitchUserNameTextBox.Text);
                var channelId = _twitchApiController.GetTwitchChannelId();
                
                _twitchPubSubController = new TwitchPubSubController(_twitchClientController, channelId, _twitchApiClientId, _twitchApiSecret);
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

        private void Application_Exit(object sender, EventArgs e)
        {
            SaveSecretValue();
            Application.ApplicationExit -= Application_Exit;
        }
        
        private void FollowTestButton_Click(object sender, EventArgs e)
        {
            // _twitchClientController
        }
    }
}