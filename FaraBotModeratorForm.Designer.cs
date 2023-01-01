using System.ComponentModel;

namespace FaraBotModerator
{
    partial class FaraBotModeratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaraBotModeratorForm));
            this.MenuTab = new System.Windows.Forms.TabControl();
            this.MainSettingTab = new System.Windows.Forms.TabPage();
            this.ChatBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.TwitterGroupBox = new System.Windows.Forms.GroupBox();
            this.TwitterTweetTextBox = new System.Windows.Forms.GroupBox();
            this.TwitterSendRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TwitterAPISecretTextBox = new System.Windows.Forms.TextBox();
            this.TwitterAPIKeyTextBox = new System.Windows.Forms.TextBox();
            this.TwitterAPISecretLabel = new System.Windows.Forms.Label();
            this.TwitterAPIKeyLabel = new System.Windows.Forms.Label();
            this.TwitterPushTweetButton = new System.Windows.Forms.Button();
            this.TwitterConnectionStateLabel = new System.Windows.Forms.Label();
            this.TwitterConnectionButton = new System.Windows.Forms.Button();
            this.TwitterDisconnectionButton = new System.Windows.Forms.Button();
            this.TwitchGroupBox = new System.Windows.Forms.GroupBox();
            this.BouyomiChanConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.TwitchChannelNameLabel = new System.Windows.Forms.Label();
            this.TwitchAccessTokenButton = new System.Windows.Forms.Button();
            this.TwitchConnectionStateLabel = new System.Windows.Forms.Label();
            this.TwitchDisconnectButton = new System.Windows.Forms.Button();
            this.TwitchConnectionButton = new System.Windows.Forms.Button();
            this.TwitchAccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.TwitchUserNameTextBox = new System.Windows.Forms.TextBox();
            this.TwitchAccessTokenLabel = new System.Windows.Forms.Label();
            this.TwitchUserNameLabel = new System.Windows.Forms.Label();
            this.ReactionEventTab = new System.Windows.Forms.TabPage();
            this.GiftTestButton = new System.Windows.Forms.Button();
            this.BitsTestButton = new System.Windows.Forms.Button();
            this.SubscriptionTestButton = new System.Windows.Forms.Button();
            this.RaidTestButton = new System.Windows.Forms.Button();
            this.FollowTestButton = new System.Windows.Forms.Button();
            this.GiftEventTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ReplaceNotificationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BitsEventTextBox = new System.Windows.Forms.TextBox();
            this.SubscriptionEventTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RaidEventTextBox = new System.Windows.Forms.TextBox();
            this.RaidTextLabel = new System.Windows.Forms.Label();
            this.FollowEventTextBox = new System.Windows.Forms.TextBox();
            this.FollowedTextLabel = new System.Windows.Forms.Label();
            this.AutoBotTab = new System.Windows.Forms.TabPage();
            this.AutoBotChildTab = new System.Windows.Forms.TabControl();
            this.TranslateTab = new System.Windows.Forms.TabPage();
            this.DeepLAPIProGroupBox = new System.Windows.Forms.GroupBox();
            this.DeepLAPIProAuthKeyTextBox = new System.Windows.Forms.TextBox();
            this.DeepLAPIProAuthKeyLabel = new System.Windows.Forms.Label();
            this.DeepLAPIFreeGroupBox = new System.Windows.Forms.GroupBox();
            this.DeepLAPIFreeAuthKeyTextBox = new System.Windows.Forms.TextBox();
            this.DeepLAPIFreeAuthKeyLabel = new System.Windows.Forms.Label();
            this.TimerTab = new System.Windows.Forms.TabPage();
            this.FixedNotificationGroupBox = new System.Windows.Forms.GroupBox();
            this.CycleNotificationGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.MenuTab.SuspendLayout();
            this.MainSettingTab.SuspendLayout();
            this.TwitterGroupBox.SuspendLayout();
            this.TwitterTweetTextBox.SuspendLayout();
            this.TwitchGroupBox.SuspendLayout();
            this.ReactionEventTab.SuspendLayout();
            this.AutoBotTab.SuspendLayout();
            this.AutoBotChildTab.SuspendLayout();
            this.TranslateTab.SuspendLayout();
            this.DeepLAPIProGroupBox.SuspendLayout();
            this.DeepLAPIFreeGroupBox.SuspendLayout();
            this.TimerTab.SuspendLayout();
            this.CycleNotificationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.MainSettingTab);
            this.MenuTab.Controls.Add(this.ReactionEventTab);
            this.MenuTab.Controls.Add(this.AutoBotTab);
            this.MenuTab.Location = new System.Drawing.Point(12, 12);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.SelectedIndex = 0;
            this.MenuTab.Size = new System.Drawing.Size(776, 426);
            this.MenuTab.TabIndex = 0;
            // 
            // MainSettingTab
            // 
            this.MainSettingTab.Controls.Add(this.ChatBoxGroupBox);
            this.MainSettingTab.Controls.Add(this.TwitterGroupBox);
            this.MainSettingTab.Controls.Add(this.TwitchGroupBox);
            this.MainSettingTab.Location = new System.Drawing.Point(4, 22);
            this.MainSettingTab.Name = "MainSettingTab";
            this.MainSettingTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainSettingTab.Size = new System.Drawing.Size(768, 400);
            this.MainSettingTab.TabIndex = 0;
            this.MainSettingTab.Text = "Main Settings";
            this.MainSettingTab.ToolTipText = "Twitch接続やTwitter送信の設定を行います。";
            this.MainSettingTab.UseVisualStyleBackColor = true;
            // 
            // ChatBoxGroupBox
            // 
            this.ChatBoxGroupBox.Location = new System.Drawing.Point(365, 6);
            this.ChatBoxGroupBox.Name = "ChatBoxGroupBox";
            this.ChatBoxGroupBox.Size = new System.Drawing.Size(397, 388);
            this.ChatBoxGroupBox.TabIndex = 2;
            this.ChatBoxGroupBox.TabStop = false;
            this.ChatBoxGroupBox.Text = "ChatBox";
            // 
            // TwitterGroupBox
            // 
            this.TwitterGroupBox.Controls.Add(this.TwitterTweetTextBox);
            this.TwitterGroupBox.Controls.Add(this.TwitterAPISecretTextBox);
            this.TwitterGroupBox.Controls.Add(this.TwitterAPIKeyTextBox);
            this.TwitterGroupBox.Controls.Add(this.TwitterAPISecretLabel);
            this.TwitterGroupBox.Controls.Add(this.TwitterAPIKeyLabel);
            this.TwitterGroupBox.Controls.Add(this.TwitterPushTweetButton);
            this.TwitterGroupBox.Controls.Add(this.TwitterConnectionStateLabel);
            this.TwitterGroupBox.Controls.Add(this.TwitterConnectionButton);
            this.TwitterGroupBox.Controls.Add(this.TwitterDisconnectionButton);
            this.TwitterGroupBox.Location = new System.Drawing.Point(6, 203);
            this.TwitterGroupBox.Name = "TwitterGroupBox";
            this.TwitterGroupBox.Size = new System.Drawing.Size(353, 191);
            this.TwitterGroupBox.TabIndex = 1;
            this.TwitterGroupBox.TabStop = false;
            this.TwitterGroupBox.Text = "Twitter";
            // 
            // TwitterTweetTextBox
            // 
            this.TwitterTweetTextBox.Controls.Add(this.TwitterSendRichTextBox);
            this.TwitterTweetTextBox.Location = new System.Drawing.Point(6, 70);
            this.TwitterTweetTextBox.Name = "TwitterTweetTextBox";
            this.TwitterTweetTextBox.Size = new System.Drawing.Size(341, 86);
            this.TwitterTweetTextBox.TabIndex = 10;
            this.TwitterTweetTextBox.TabStop = false;
            this.TwitterTweetTextBox.Text = "Tweet";
            // 
            // TwitterSendRichTextBox
            // 
            this.TwitterSendRichTextBox.Location = new System.Drawing.Point(6, 18);
            this.TwitterSendRichTextBox.Name = "TwitterSendRichTextBox";
            this.TwitterSendRichTextBox.Size = new System.Drawing.Size(329, 62);
            this.TwitterSendRichTextBox.TabIndex = 4;
            this.TwitterSendRichTextBox.Text = "test\n\n@game_Fara";
            // 
            // TwitterAPISecretTextBox
            // 
            this.TwitterAPISecretTextBox.Location = new System.Drawing.Point(112, 37);
            this.TwitterAPISecretTextBox.Name = "TwitterAPISecretTextBox";
            this.TwitterAPISecretTextBox.PasswordChar = '●';
            this.TwitterAPISecretTextBox.Size = new System.Drawing.Size(235, 19);
            this.TwitterAPISecretTextBox.TabIndex = 9;
            // 
            // TwitterAPIKeyTextBox
            // 
            this.TwitterAPIKeyTextBox.Location = new System.Drawing.Point(112, 12);
            this.TwitterAPIKeyTextBox.Name = "TwitterAPIKeyTextBox";
            this.TwitterAPIKeyTextBox.PasswordChar = '●';
            this.TwitterAPIKeyTextBox.Size = new System.Drawing.Size(235, 19);
            this.TwitterAPIKeyTextBox.TabIndex = 8;
            // 
            // TwitterAPISecretLabel
            // 
            this.TwitterAPISecretLabel.Location = new System.Drawing.Point(6, 37);
            this.TwitterAPISecretLabel.Name = "TwitterAPISecretLabel";
            this.TwitterAPISecretLabel.Size = new System.Drawing.Size(100, 16);
            this.TwitterAPISecretLabel.TabIndex = 7;
            this.TwitterAPISecretLabel.Text = "API Secret";
            this.TwitterAPISecretLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitterAPIKeyLabel
            // 
            this.TwitterAPIKeyLabel.Location = new System.Drawing.Point(6, 15);
            this.TwitterAPIKeyLabel.Name = "TwitterAPIKeyLabel";
            this.TwitterAPIKeyLabel.Size = new System.Drawing.Size(100, 16);
            this.TwitterAPIKeyLabel.TabIndex = 6;
            this.TwitterAPIKeyLabel.Text = "API Key";
            this.TwitterAPIKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitterPushTweetButton
            // 
            this.TwitterPushTweetButton.Enabled = false;
            this.TwitterPushTweetButton.Location = new System.Drawing.Point(112, 162);
            this.TwitterPushTweetButton.Name = "TwitterPushTweetButton";
            this.TwitterPushTweetButton.Size = new System.Drawing.Size(75, 23);
            this.TwitterPushTweetButton.TabIndex = 5;
            this.TwitterPushTweetButton.Text = "Tweet";
            this.TwitterPushTweetButton.UseVisualStyleBackColor = true;
            this.TwitterPushTweetButton.Click += new System.EventHandler(this.TwitterPushTweetButton_Click);
            // 
            // TwitterConnectionStateLabel
            // 
            this.TwitterConnectionStateLabel.Location = new System.Drawing.Point(3, 167);
            this.TwitterConnectionStateLabel.Name = "TwitterConnectionStateLabel";
            this.TwitterConnectionStateLabel.Size = new System.Drawing.Size(103, 15);
            this.TwitterConnectionStateLabel.TabIndex = 3;
            this.TwitterConnectionStateLabel.Text = "State: Disconnect";
            this.TwitterConnectionStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitterConnectionButton
            // 
            this.TwitterConnectionButton.Location = new System.Drawing.Point(193, 162);
            this.TwitterConnectionButton.Name = "TwitterConnectionButton";
            this.TwitterConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.TwitterConnectionButton.TabIndex = 0;
            this.TwitterConnectionButton.Text = "Connect";
            this.TwitterConnectionButton.UseVisualStyleBackColor = true;
            this.TwitterConnectionButton.Click += new System.EventHandler(this.TwitterConnectionButton_Click);
            // 
            // TwitterDisconnectionButton
            // 
            this.TwitterDisconnectionButton.Location = new System.Drawing.Point(272, 162);
            this.TwitterDisconnectionButton.Name = "TwitterDisconnectionButton";
            this.TwitterDisconnectionButton.Size = new System.Drawing.Size(75, 23);
            this.TwitterDisconnectionButton.TabIndex = 1;
            this.TwitterDisconnectionButton.Text = "Disconnect";
            this.TwitterDisconnectionButton.UseVisualStyleBackColor = true;
            this.TwitterDisconnectionButton.Click += new System.EventHandler(this.TwitterDisconnectionButton_Click);
            // 
            // TwitchGroupBox
            // 
            this.TwitchGroupBox.Controls.Add(this.BouyomiChanConnectCheckBox);
            this.TwitchGroupBox.Controls.Add(this.TwitchChannelNameLabel);
            this.TwitchGroupBox.Controls.Add(this.TwitchAccessTokenButton);
            this.TwitchGroupBox.Controls.Add(this.TwitchConnectionStateLabel);
            this.TwitchGroupBox.Controls.Add(this.TwitchDisconnectButton);
            this.TwitchGroupBox.Controls.Add(this.TwitchConnectionButton);
            this.TwitchGroupBox.Controls.Add(this.TwitchAccessTokenTextBox);
            this.TwitchGroupBox.Controls.Add(this.TwitchUserNameTextBox);
            this.TwitchGroupBox.Controls.Add(this.TwitchAccessTokenLabel);
            this.TwitchGroupBox.Controls.Add(this.TwitchUserNameLabel);
            this.TwitchGroupBox.Location = new System.Drawing.Point(6, 6);
            this.TwitchGroupBox.Name = "TwitchGroupBox";
            this.TwitchGroupBox.Size = new System.Drawing.Size(353, 191);
            this.TwitchGroupBox.TabIndex = 0;
            this.TwitchGroupBox.TabStop = false;
            this.TwitchGroupBox.Text = "Twitch";
            // 
            // BouyomiChanConnectCheckBox
            // 
            this.BouyomiChanConnectCheckBox.Checked = true;
            this.BouyomiChanConnectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BouyomiChanConnectCheckBox.Location = new System.Drawing.Point(6, 79);
            this.BouyomiChanConnectCheckBox.Name = "BouyomiChanConnectCheckBox";
            this.BouyomiChanConnectCheckBox.Size = new System.Drawing.Size(146, 24);
            this.BouyomiChanConnectCheckBox.TabIndex = 9;
            this.BouyomiChanConnectCheckBox.Text = "BouyomiChanConnect";
            this.BouyomiChanConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // TwitchChannelNameLabel
            // 
            this.TwitchChannelNameLabel.Location = new System.Drawing.Point(6, 64);
            this.TwitchChannelNameLabel.Name = "TwitchChannelNameLabel";
            this.TwitchChannelNameLabel.Size = new System.Drawing.Size(260, 21);
            this.TwitchChannelNameLabel.TabIndex = 8;
            this.TwitchChannelNameLabel.Text = "ChannelName: xxx";
            // 
            // TwitchAccessTokenButton
            // 
            this.TwitchAccessTokenButton.Location = new System.Drawing.Point(272, 62);
            this.TwitchAccessTokenButton.Name = "TwitchAccessTokenButton";
            this.TwitchAccessTokenButton.Size = new System.Drawing.Size(75, 23);
            this.TwitchAccessTokenButton.TabIndex = 7;
            this.TwitchAccessTokenButton.Text = "Get Token";
            this.TwitchAccessTokenButton.UseVisualStyleBackColor = true;
            this.TwitchAccessTokenButton.Click += new System.EventHandler(this.TwitchAccessTokenButton_Click);
            // 
            // TwitchConnectionStateLabel
            // 
            this.TwitchConnectionStateLabel.Location = new System.Drawing.Point(6, 167);
            this.TwitchConnectionStateLabel.Name = "TwitchConnectionStateLabel";
            this.TwitchConnectionStateLabel.Size = new System.Drawing.Size(100, 13);
            this.TwitchConnectionStateLabel.TabIndex = 6;
            this.TwitchConnectionStateLabel.Text = "State: Disconnect";
            // 
            // TwitchDisconnectButton
            // 
            this.TwitchDisconnectButton.Location = new System.Drawing.Point(272, 162);
            this.TwitchDisconnectButton.Name = "TwitchDisconnectButton";
            this.TwitchDisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.TwitchDisconnectButton.TabIndex = 5;
            this.TwitchDisconnectButton.Text = "Disconnect";
            this.TwitchDisconnectButton.UseVisualStyleBackColor = true;
            this.TwitchDisconnectButton.Click += new System.EventHandler(this.TwitchDisconnectButton_Click);
            // 
            // TwitchConnectionButton
            // 
            this.TwitchConnectionButton.Location = new System.Drawing.Point(193, 162);
            this.TwitchConnectionButton.Name = "TwitchConnectionButton";
            this.TwitchConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.TwitchConnectionButton.TabIndex = 4;
            this.TwitchConnectionButton.Text = "Connect";
            this.TwitchConnectionButton.UseVisualStyleBackColor = true;
            this.TwitchConnectionButton.Click += new System.EventHandler(this.TwitchConnectionButton_Click);
            // 
            // TwitchAccessTokenTextBox
            // 
            this.TwitchAccessTokenTextBox.Location = new System.Drawing.Point(112, 37);
            this.TwitchAccessTokenTextBox.Name = "TwitchAccessTokenTextBox";
            this.TwitchAccessTokenTextBox.PasswordChar = '●';
            this.TwitchAccessTokenTextBox.Size = new System.Drawing.Size(235, 19);
            this.TwitchAccessTokenTextBox.TabIndex = 3;
            // 
            // TwitchUserNameTextBox
            // 
            this.TwitchUserNameTextBox.Location = new System.Drawing.Point(112, 12);
            this.TwitchUserNameTextBox.Name = "TwitchUserNameTextBox";
            this.TwitchUserNameTextBox.Size = new System.Drawing.Size(235, 19);
            this.TwitchUserNameTextBox.TabIndex = 2;
            // 
            // TwitchAccessTokenLabel
            // 
            this.TwitchAccessTokenLabel.Location = new System.Drawing.Point(6, 37);
            this.TwitchAccessTokenLabel.Name = "TwitchAccessTokenLabel";
            this.TwitchAccessTokenLabel.Size = new System.Drawing.Size(100, 16);
            this.TwitchAccessTokenLabel.TabIndex = 1;
            this.TwitchAccessTokenLabel.Text = "AccessToken";
            this.TwitchAccessTokenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitchUserNameLabel
            // 
            this.TwitchUserNameLabel.Location = new System.Drawing.Point(6, 15);
            this.TwitchUserNameLabel.Name = "TwitchUserNameLabel";
            this.TwitchUserNameLabel.Size = new System.Drawing.Size(100, 16);
            this.TwitchUserNameLabel.TabIndex = 0;
            this.TwitchUserNameLabel.Text = "UserName";
            this.TwitchUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReactionEventTab
            // 
            this.ReactionEventTab.Controls.Add(this.GiftTestButton);
            this.ReactionEventTab.Controls.Add(this.BitsTestButton);
            this.ReactionEventTab.Controls.Add(this.SubscriptionTestButton);
            this.ReactionEventTab.Controls.Add(this.RaidTestButton);
            this.ReactionEventTab.Controls.Add(this.FollowTestButton);
            this.ReactionEventTab.Controls.Add(this.GiftEventTextBox);
            this.ReactionEventTab.Controls.Add(this.label3);
            this.ReactionEventTab.Controls.Add(this.ReplaceNotificationTextBox);
            this.ReactionEventTab.Controls.Add(this.label2);
            this.ReactionEventTab.Controls.Add(this.BitsEventTextBox);
            this.ReactionEventTab.Controls.Add(this.SubscriptionEventTextBox);
            this.ReactionEventTab.Controls.Add(this.label1);
            this.ReactionEventTab.Controls.Add(this.RaidEventTextBox);
            this.ReactionEventTab.Controls.Add(this.RaidTextLabel);
            this.ReactionEventTab.Controls.Add(this.FollowEventTextBox);
            this.ReactionEventTab.Controls.Add(this.FollowedTextLabel);
            this.ReactionEventTab.Location = new System.Drawing.Point(4, 22);
            this.ReactionEventTab.Name = "ReactionEventTab";
            this.ReactionEventTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReactionEventTab.Size = new System.Drawing.Size(768, 400);
            this.ReactionEventTab.TabIndex = 1;
            this.ReactionEventTab.Text = "Reaction Event";
            this.ReactionEventTab.ToolTipText = "TwitchでFollowやRaid等のアクションに応じた設定を行います。";
            this.ReactionEventTab.UseVisualStyleBackColor = true;
            // 
            // GiftTestButton
            // 
            this.GiftTestButton.Location = new System.Drawing.Point(711, 106);
            this.GiftTestButton.Name = "GiftTestButton";
            this.GiftTestButton.Size = new System.Drawing.Size(51, 19);
            this.GiftTestButton.TabIndex = 26;
            this.GiftTestButton.Text = "Test";
            this.GiftTestButton.UseVisualStyleBackColor = true;
            // 
            // BitsTestButton
            // 
            this.BitsTestButton.Location = new System.Drawing.Point(711, 81);
            this.BitsTestButton.Name = "BitsTestButton";
            this.BitsTestButton.Size = new System.Drawing.Size(51, 19);
            this.BitsTestButton.TabIndex = 25;
            this.BitsTestButton.Text = "Test";
            this.BitsTestButton.UseVisualStyleBackColor = true;
            // 
            // SubscriptionTestButton
            // 
            this.SubscriptionTestButton.Location = new System.Drawing.Point(711, 56);
            this.SubscriptionTestButton.Name = "SubscriptionTestButton";
            this.SubscriptionTestButton.Size = new System.Drawing.Size(51, 19);
            this.SubscriptionTestButton.TabIndex = 24;
            this.SubscriptionTestButton.Text = "Test";
            this.SubscriptionTestButton.UseVisualStyleBackColor = true;
            // 
            // RaidTestButton
            // 
            this.RaidTestButton.Location = new System.Drawing.Point(711, 31);
            this.RaidTestButton.Name = "RaidTestButton";
            this.RaidTestButton.Size = new System.Drawing.Size(51, 19);
            this.RaidTestButton.TabIndex = 23;
            this.RaidTestButton.Text = "Test";
            this.RaidTestButton.UseVisualStyleBackColor = true;
            // 
            // FollowTestButton
            // 
            this.FollowTestButton.Location = new System.Drawing.Point(711, 6);
            this.FollowTestButton.Name = "FollowTestButton";
            this.FollowTestButton.Size = new System.Drawing.Size(51, 19);
            this.FollowTestButton.TabIndex = 22;
            this.FollowTestButton.Text = "Test";
            this.FollowTestButton.UseVisualStyleBackColor = true;
            this.FollowTestButton.Click += new System.EventHandler(this.FollowTestButton_Click);
            // 
            // GiftEventTextBox
            // 
            this.GiftEventTextBox.Location = new System.Drawing.Point(90, 106);
            this.GiftEventTextBox.Name = "GiftEventTextBox";
            this.GiftEventTextBox.Size = new System.Drawing.Size(615, 19);
            this.GiftEventTextBox.TabIndex = 21;
            this.GiftEventTextBox.Text = "Thanks gift {giftedUserName} gamefa16Hi";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Gift";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReplaceNotificationTextBox
            // 
            this.ReplaceNotificationTextBox.Location = new System.Drawing.Point(6, 131);
            this.ReplaceNotificationTextBox.Multiline = true;
            this.ReplaceNotificationTextBox.Name = "ReplaceNotificationTextBox";
            this.ReplaceNotificationTextBox.ReadOnly = true;
            this.ReplaceNotificationTextBox.Size = new System.Drawing.Size(756, 263);
            this.ReplaceNotificationTextBox.TabIndex = 19;
            this.ReplaceNotificationTextBox.Text = resources.GetString("ReplaceNotificationTextBox.Text");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Bits";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BitsEventTextBox
            // 
            this.BitsEventTextBox.Location = new System.Drawing.Point(90, 81);
            this.BitsEventTextBox.Name = "BitsEventTextBox";
            this.BitsEventTextBox.Size = new System.Drawing.Size(615, 19);
            this.BitsEventTextBox.TabIndex = 17;
            this.BitsEventTextBox.Text = "Thanks {bitsAmount} bits (total {totalBitsAmount}) {bitsSendUserName} gamefa16Hi";
            // 
            // SubscriptionEventTextBox
            // 
            this.SubscriptionEventTextBox.Location = new System.Drawing.Point(90, 56);
            this.SubscriptionEventTextBox.Name = "SubscriptionEventTextBox";
            this.SubscriptionEventTextBox.Size = new System.Drawing.Size(615, 19);
            this.SubscriptionEventTextBox.TabIndex = 16;
            this.SubscriptionEventTextBox.Text = "Thanks subscription {subscriberName} gamefa16Hi";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Subscription";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RaidEventTextBox
            // 
            this.RaidEventTextBox.Location = new System.Drawing.Point(90, 31);
            this.RaidEventTextBox.Name = "RaidEventTextBox";
            this.RaidEventTextBox.Size = new System.Drawing.Size(615, 19);
            this.RaidEventTextBox.TabIndex = 14;
            this.RaidEventTextBox.Text = "Welcome raiders, thanks raid {raiderName} gamefa16Hi. Please follow us! {url}";
            // 
            // RaidTextLabel
            // 
            this.RaidTextLabel.Location = new System.Drawing.Point(6, 31);
            this.RaidTextLabel.Name = "RaidTextLabel";
            this.RaidTextLabel.Size = new System.Drawing.Size(78, 19);
            this.RaidTextLabel.TabIndex = 13;
            this.RaidTextLabel.Text = "Raid";
            this.RaidTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FollowEventTextBox
            // 
            this.FollowEventTextBox.Location = new System.Drawing.Point(90, 6);
            this.FollowEventTextBox.Name = "FollowEventTextBox";
            this.FollowEventTextBox.Size = new System.Drawing.Size(615, 19);
            this.FollowEventTextBox.TabIndex = 12;
            this.FollowEventTextBox.Text = "{followerName}, thanks follow gamefa16Hi. Follower Channel URL: {followerChannelU" + "rl}";
            // 
            // FollowedTextLabel
            // 
            this.FollowedTextLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FollowedTextLabel.Location = new System.Drawing.Point(6, 6);
            this.FollowedTextLabel.Name = "FollowedTextLabel";
            this.FollowedTextLabel.Size = new System.Drawing.Size(78, 19);
            this.FollowedTextLabel.TabIndex = 11;
            this.FollowedTextLabel.Text = "Follow";
            this.FollowedTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoBotTab
            // 
            this.AutoBotTab.Controls.Add(this.AutoBotChildTab);
            this.AutoBotTab.Location = new System.Drawing.Point(4, 22);
            this.AutoBotTab.Name = "AutoBotTab";
            this.AutoBotTab.Size = new System.Drawing.Size(768, 400);
            this.AutoBotTab.TabIndex = 2;
            this.AutoBotTab.Text = "Auto Bot";
            this.AutoBotTab.ToolTipText = "定期的なチャット通知や翻訳設定を行います。";
            this.AutoBotTab.UseVisualStyleBackColor = true;
            // 
            // AutoBotChildTab
            // 
            this.AutoBotChildTab.Controls.Add(this.TranslateTab);
            this.AutoBotChildTab.Controls.Add(this.TimerTab);
            this.AutoBotChildTab.Location = new System.Drawing.Point(3, 3);
            this.AutoBotChildTab.Name = "AutoBotChildTab";
            this.AutoBotChildTab.SelectedIndex = 0;
            this.AutoBotChildTab.Size = new System.Drawing.Size(762, 394);
            this.AutoBotChildTab.TabIndex = 0;
            // 
            // TranslateTab
            // 
            this.TranslateTab.Controls.Add(this.DeepLAPIProGroupBox);
            this.TranslateTab.Controls.Add(this.DeepLAPIFreeGroupBox);
            this.TranslateTab.Location = new System.Drawing.Point(4, 22);
            this.TranslateTab.Name = "TranslateTab";
            this.TranslateTab.Padding = new System.Windows.Forms.Padding(3);
            this.TranslateTab.Size = new System.Drawing.Size(754, 368);
            this.TranslateTab.TabIndex = 0;
            this.TranslateTab.Text = "Translate";
            this.TranslateTab.ToolTipText = "チャット翻訳設定を行います。";
            this.TranslateTab.UseVisualStyleBackColor = true;
            // 
            // DeepLAPIProGroupBox
            // 
            this.DeepLAPIProGroupBox.Controls.Add(this.DeepLAPIProAuthKeyTextBox);
            this.DeepLAPIProGroupBox.Controls.Add(this.DeepLAPIProAuthKeyLabel);
            this.DeepLAPIProGroupBox.Location = new System.Drawing.Point(6, 112);
            this.DeepLAPIProGroupBox.Name = "DeepLAPIProGroupBox";
            this.DeepLAPIProGroupBox.Size = new System.Drawing.Size(348, 100);
            this.DeepLAPIProGroupBox.TabIndex = 1;
            this.DeepLAPIProGroupBox.TabStop = false;
            this.DeepLAPIProGroupBox.Text = "DeepL Pro";
            // 
            // DeepLAPIProAuthKeyTextBox
            // 
            this.DeepLAPIProAuthKeyTextBox.Location = new System.Drawing.Point(65, 17);
            this.DeepLAPIProAuthKeyTextBox.Name = "DeepLAPIProAuthKeyTextBox";
            this.DeepLAPIProAuthKeyTextBox.PasswordChar = '●';
            this.DeepLAPIProAuthKeyTextBox.Size = new System.Drawing.Size(277, 19);
            this.DeepLAPIProAuthKeyTextBox.TabIndex = 1;
            // 
            // DeepLAPIProAuthKeyLabel
            // 
            this.DeepLAPIProAuthKeyLabel.Location = new System.Drawing.Point(6, 15);
            this.DeepLAPIProAuthKeyLabel.Name = "DeepLAPIProAuthKeyLabel";
            this.DeepLAPIProAuthKeyLabel.Size = new System.Drawing.Size(53, 23);
            this.DeepLAPIProAuthKeyLabel.TabIndex = 0;
            this.DeepLAPIProAuthKeyLabel.Text = "Auth Key";
            this.DeepLAPIProAuthKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeepLAPIFreeGroupBox
            // 
            this.DeepLAPIFreeGroupBox.Controls.Add(this.DeepLAPIFreeAuthKeyTextBox);
            this.DeepLAPIFreeGroupBox.Controls.Add(this.DeepLAPIFreeAuthKeyLabel);
            this.DeepLAPIFreeGroupBox.Location = new System.Drawing.Point(6, 6);
            this.DeepLAPIFreeGroupBox.Name = "DeepLAPIFreeGroupBox";
            this.DeepLAPIFreeGroupBox.Size = new System.Drawing.Size(348, 100);
            this.DeepLAPIFreeGroupBox.TabIndex = 0;
            this.DeepLAPIFreeGroupBox.TabStop = false;
            this.DeepLAPIFreeGroupBox.Text = "DeepL Free";
            // 
            // DeepLAPIFreeAuthKeyTextBox
            // 
            this.DeepLAPIFreeAuthKeyTextBox.Location = new System.Drawing.Point(65, 17);
            this.DeepLAPIFreeAuthKeyTextBox.Name = "DeepLAPIFreeAuthKeyTextBox";
            this.DeepLAPIFreeAuthKeyTextBox.PasswordChar = '●';
            this.DeepLAPIFreeAuthKeyTextBox.Size = new System.Drawing.Size(277, 19);
            this.DeepLAPIFreeAuthKeyTextBox.TabIndex = 1;
            // 
            // DeepLAPIFreeAuthKeyLabel
            // 
            this.DeepLAPIFreeAuthKeyLabel.Location = new System.Drawing.Point(6, 15);
            this.DeepLAPIFreeAuthKeyLabel.Name = "DeepLAPIFreeAuthKeyLabel";
            this.DeepLAPIFreeAuthKeyLabel.Size = new System.Drawing.Size(53, 23);
            this.DeepLAPIFreeAuthKeyLabel.TabIndex = 0;
            this.DeepLAPIFreeAuthKeyLabel.Text = "Auth Key";
            this.DeepLAPIFreeAuthKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimerTab
            // 
            this.TimerTab.Controls.Add(this.FixedNotificationGroupBox);
            this.TimerTab.Controls.Add(this.CycleNotificationGroupBox);
            this.TimerTab.Location = new System.Drawing.Point(4, 22);
            this.TimerTab.Name = "TimerTab";
            this.TimerTab.Padding = new System.Windows.Forms.Padding(3);
            this.TimerTab.Size = new System.Drawing.Size(754, 368);
            this.TimerTab.TabIndex = 1;
            this.TimerTab.Text = "Timer";
            this.TimerTab.ToolTipText = "一定時間毎のTwitchチャット通知設定を行います。";
            this.TimerTab.UseVisualStyleBackColor = true;
            // 
            // FixedNotificationGroupBox
            // 
            this.FixedNotificationGroupBox.Location = new System.Drawing.Point(6, 187);
            this.FixedNotificationGroupBox.Name = "FixedNotificationGroupBox";
            this.FixedNotificationGroupBox.Size = new System.Drawing.Size(742, 178);
            this.FixedNotificationGroupBox.TabIndex = 1;
            this.FixedNotificationGroupBox.TabStop = false;
            this.FixedNotificationGroupBox.Text = "Fixed Notifications";
            // 
            // CycleNotificationGroupBox
            // 
            this.CycleNotificationGroupBox.Controls.Add(this.checkBox2);
            this.CycleNotificationGroupBox.Controls.Add(this.textBox2);
            this.CycleNotificationGroupBox.Controls.Add(this.label5);
            this.CycleNotificationGroupBox.Controls.Add(this.numericUpDown2);
            this.CycleNotificationGroupBox.Controls.Add(this.checkBox1);
            this.CycleNotificationGroupBox.Controls.Add(this.textBox1);
            this.CycleNotificationGroupBox.Controls.Add(this.label4);
            this.CycleNotificationGroupBox.Controls.Add(this.numericUpDown1);
            this.CycleNotificationGroupBox.Location = new System.Drawing.Point(6, 3);
            this.CycleNotificationGroupBox.Name = "CycleNotificationGroupBox";
            this.CycleNotificationGroupBox.Size = new System.Drawing.Size(742, 178);
            this.CycleNotificationGroupBox.TabIndex = 0;
            this.CycleNotificationGroupBox.TabStop = false;
            this.CycleNotificationGroupBox.Text = "Cycle Notifications";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(6, 52);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(62, 24);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Timer1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(204, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(532, 19);
            this.textBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(119, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "minutes/times";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {5, 0, 0, 0});
            this.numericUpDown2.Location = new System.Drawing.Point(74, 55);
            this.numericUpDown2.Maximum = new decimal(new int[] {120, 0, 0, 0});
            this.numericUpDown2.Minimum = new decimal(new int[] {15, 0, 0, 0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(39, 19);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Tag = "";
            this.numericUpDown2.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown2.Value = new decimal(new int[] {15, 0, 0, 0});
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(6, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Timer1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(204, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(532, 19);
            this.textBox1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(119, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "minutes/times";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {5, 0, 0, 0});
            this.numericUpDown1.Location = new System.Drawing.Point(74, 21);
            this.numericUpDown1.Maximum = new decimal(new int[] {120, 0, 0, 0});
            this.numericUpDown1.Minimum = new decimal(new int[] {15, 0, 0, 0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 19);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Tag = "";
            this.numericUpDown1.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown1.Value = new decimal(new int[] {15, 0, 0, 0});
            // 
            // FaraBotModeratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuTab);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "FaraBotModeratorForm";
            this.Text = "FaraBotModerator";
            this.MenuTab.ResumeLayout(false);
            this.MainSettingTab.ResumeLayout(false);
            this.TwitterGroupBox.ResumeLayout(false);
            this.TwitterGroupBox.PerformLayout();
            this.TwitterTweetTextBox.ResumeLayout(false);
            this.TwitchGroupBox.ResumeLayout(false);
            this.TwitchGroupBox.PerformLayout();
            this.ReactionEventTab.ResumeLayout(false);
            this.ReactionEventTab.PerformLayout();
            this.AutoBotTab.ResumeLayout(false);
            this.AutoBotChildTab.ResumeLayout(false);
            this.TranslateTab.ResumeLayout(false);
            this.DeepLAPIProGroupBox.ResumeLayout(false);
            this.DeepLAPIProGroupBox.PerformLayout();
            this.DeepLAPIFreeGroupBox.ResumeLayout(false);
            this.DeepLAPIFreeGroupBox.PerformLayout();
            this.TimerTab.ResumeLayout(false);
            this.CycleNotificationGroupBox.ResumeLayout(false);
            this.CycleNotificationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox BouyomiChanConnectCheckBox;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.NumericUpDown numericUpDown1;

        private System.Windows.Forms.Button FollowTestButton;
        private System.Windows.Forms.Button RaidTestButton;
        private System.Windows.Forms.Button SubscriptionTestButton;
        private System.Windows.Forms.Button BitsTestButton;
        private System.Windows.Forms.Button GiftTestButton;

        private System.Windows.Forms.TextBox GiftEventTextBox;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox ReplaceNotificationTextBox;

        private System.Windows.Forms.TextBox BitsEventTextBox;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SubscriptionEventTextBox;

        private System.Windows.Forms.TextBox RaidEventTextBox;

        private System.Windows.Forms.Label RaidTextLabel;

        private System.Windows.Forms.TextBox FollowEventTextBox;

        private System.Windows.Forms.Label FollowedTextLabel;

        private System.Windows.Forms.GroupBox CycleNotificationGroupBox;

        private System.Windows.Forms.GroupBox FixedNotificationGroupBox;

        private System.Windows.Forms.TextBox DeepLAPIFreeAuthKeyTextBox;
        private System.Windows.Forms.TextBox DeepLAPIProAuthKeyTextBox;

        private System.Windows.Forms.Label DeepLAPIFreeAuthKeyLabel;

        private System.Windows.Forms.Label DeepLAPIProAuthKeyLabel;

        private System.Windows.Forms.GroupBox DeepLAPIFreeGroupBox;
        private System.Windows.Forms.GroupBox DeepLAPIProGroupBox;

        private System.Windows.Forms.Label TwitchChannelNameLabel;

        private System.Windows.Forms.GroupBox TwitterTweetTextBox;

        private System.Windows.Forms.TextBox TwitterAPIKeyTextBox;
        private System.Windows.Forms.TextBox TwitterAPISecretTextBox;

        private System.Windows.Forms.Label TwitterAPIKeyLabel;

        private System.Windows.Forms.Label TwitterAPISecretLabel;

        private System.Windows.Forms.Button TwitchAccessTokenButton;

        private System.Windows.Forms.GroupBox ChatBoxGroupBox;

        private System.Windows.Forms.Button TwitterPushTweetButton;

        private System.Windows.Forms.RichTextBox TwitterSendRichTextBox;

        private System.Windows.Forms.Button TwitterConnectionButton;
        private System.Windows.Forms.Label TwitterConnectionStateLabel;

        private System.Windows.Forms.Button TwitterDisconnectionButton;

        private System.Windows.Forms.GroupBox TwitterGroupBox;

        private System.Windows.Forms.Label TwitchConnectionStateLabel;

        public System.Windows.Forms.TextBox TwitchUserNameTextBox;

        private System.Windows.Forms.Label TwitchAccessTokenLabel;

        private System.Windows.Forms.TextBox TwitchAccessTokenTextBox;

        private System.Windows.Forms.Label TwitchUserNameLabel;

        private System.Windows.Forms.Button TwitchDisconnectButton;

        private System.Windows.Forms.Button TwitchConnectionButton;

        private System.Windows.Forms.GroupBox TwitchGroupBox;

        private System.Windows.Forms.TabControl AutoBotChildTab;
        private System.Windows.Forms.TabPage TranslateTab;

        private System.Windows.Forms.TabPage TimerTab;

        private System.Windows.Forms.TabPage MainSettingTab;

        private System.Windows.Forms.TabControl MenuTab;
        private System.Windows.Forms.TabPage AutoBotTab;
        private System.Windows.Forms.TabPage ReactionEventTab;

        #endregion
    }
}