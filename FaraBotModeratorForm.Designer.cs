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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MenuTab = new System.Windows.Forms.TabControl();
            this.MainSettingTab = new System.Windows.Forms.TabPage();
            this.ChatBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.TwitterGroupBox = new System.Windows.Forms.GroupBox();
            this.TwitterApiButton = new System.Windows.Forms.Button();
            this.TwitterTweetTextBox = new System.Windows.Forms.GroupBox();
            this.TwitterSendRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TwitterApiSecretTextBox = new System.Windows.Forms.TextBox();
            this.TwitterApiKeyTextBox = new System.Windows.Forms.TextBox();
            this.TwitterApiSecretLabel = new System.Windows.Forms.Label();
            this.TwitterApiKeyLabel = new System.Windows.Forms.Label();
            this.TwitterPushTweetButton = new System.Windows.Forms.Button();
            this.TwitterConnectionStateLabel = new System.Windows.Forms.Label();
            this.TwitterConnectionButton = new System.Windows.Forms.Button();
            this.TwitterDisconnectionButton = new System.Windows.Forms.Button();
            this.TwitchGroupBox = new System.Windows.Forms.GroupBox();
            this.TwitchApiGroupBox = new System.Windows.Forms.GroupBox();
            this.TwitchApiAuthorizeButton = new System.Windows.Forms.Button();
            this.TwitchApiClientSecretTextBox = new System.Windows.Forms.TextBox();
            this.TwitchApiClientSecretLabel = new System.Windows.Forms.Label();
            this.TwitchApiClientIdTextBox = new System.Windows.Forms.TextBox();
            this.TwitchApiClientIdLabel = new System.Windows.Forms.Label();
            this.TwitchClientGroupBox = new System.Windows.Forms.GroupBox();
            this.TwitchClientAccessTokenButton = new System.Windows.Forms.Button();
            this.TwitchClientUserNameLabel = new System.Windows.Forms.Label();
            this.TwitchClientAccessTokenLabel = new System.Windows.Forms.Label();
            this.TwitchClientUserNameTextBox = new System.Windows.Forms.TextBox();
            this.TwitchClientAccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.BouyomiChanConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.TwitchConnectionStateLabel = new System.Windows.Forms.Label();
            this.TwitchDisconnectButton = new System.Windows.Forms.Button();
            this.TwitchConnectionButton = new System.Windows.Forms.Button();
            this.ReactionEventTab = new System.Windows.Forms.TabPage();
            this.ChannelPointCheckBox = new System.Windows.Forms.CheckBox();
            this.GiftCheckBox = new System.Windows.Forms.CheckBox();
            this.BitsCheckBox = new System.Windows.Forms.CheckBox();
            this.SubscriptionCheckBox = new System.Windows.Forms.CheckBox();
            this.RaidCheckBox = new System.Windows.Forms.CheckBox();
            this.FollowCheckBox = new System.Windows.Forms.CheckBox();
            this.ChannelPointTestButton = new System.Windows.Forms.Button();
            this.ChannelPointEventTextBox = new System.Windows.Forms.TextBox();
            this.GiftTestButton = new System.Windows.Forms.Button();
            this.BitsTestButton = new System.Windows.Forms.Button();
            this.SubscriptionTestButton = new System.Windows.Forms.Button();
            this.RaidTestButton = new System.Windows.Forms.Button();
            this.FollowTestButton = new System.Windows.Forms.Button();
            this.GiftEventTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceNotificationTextBox = new System.Windows.Forms.TextBox();
            this.BitsEventTextBox = new System.Windows.Forms.TextBox();
            this.SubscriptionEventTextBox = new System.Windows.Forms.TextBox();
            this.RaidEventTextBox = new System.Windows.Forms.TextBox();
            this.FollowEventTextBox = new System.Windows.Forms.TextBox();
            this.AutoBotTab = new System.Windows.Forms.TabPage();
            this.AutoBotChildTab = new System.Windows.Forms.TabControl();
            this.TranslateTab = new System.Windows.Forms.TabPage();
            this.DeepLCautionLabel = new System.Windows.Forms.Label();
            this.DeepLApiKeyTextBox = new System.Windows.Forms.TextBox();
            this.DeepLApiKeyLabel = new System.Windows.Forms.Label();
            this.DeepLUsageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TimerTab = new System.Windows.Forms.TabPage();
            this.FixedNotificationGroupBox = new System.Windows.Forms.GroupBox();
            this.FixedTimer5TextBox = new System.Windows.Forms.TextBox();
            this.FixedTimer5CheckBox = new System.Windows.Forms.CheckBox();
            this.FixedTimer5DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FixedTimer4TextBox = new System.Windows.Forms.TextBox();
            this.FixedTimer4CheckBox = new System.Windows.Forms.CheckBox();
            this.FixedTimer4DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FixedTimer3TextBox = new System.Windows.Forms.TextBox();
            this.FixedTimer3CheckBox = new System.Windows.Forms.CheckBox();
            this.FixedTimer3DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FixedTimer2TextBox = new System.Windows.Forms.TextBox();
            this.FixedTimer2CheckBox = new System.Windows.Forms.CheckBox();
            this.FixedTimer2DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FixedTimer1TextBox = new System.Windows.Forms.TextBox();
            this.FixedTimer1CheckBox = new System.Windows.Forms.CheckBox();
            this.FixedTimer1DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CycleNotificationGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Timer4CheckBox = new System.Windows.Forms.CheckBox();
            this.Timer4TextBox = new System.Windows.Forms.TextBox();
            this.Timer4Label = new System.Windows.Forms.Label();
            this.Timer4NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Timer3CheckBox = new System.Windows.Forms.CheckBox();
            this.Timer3TextBox = new System.Windows.Forms.TextBox();
            this.Timer3Label = new System.Windows.Forms.Label();
            this.Timer3NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Timer2CheckBox = new System.Windows.Forms.CheckBox();
            this.Timer1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Timer2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Timer2TextBox = new System.Windows.Forms.TextBox();
            this.Timer2Label = new System.Windows.Forms.Label();
            this.Timer1CheckBox = new System.Windows.Forms.CheckBox();
            this.Timer1TextBox = new System.Windows.Forms.TextBox();
            this.Timer1Label = new System.Windows.Forms.Label();
            this.MenuTab.SuspendLayout();
            this.MainSettingTab.SuspendLayout();
            this.TwitterGroupBox.SuspendLayout();
            this.TwitterTweetTextBox.SuspendLayout();
            this.TwitchGroupBox.SuspendLayout();
            this.TwitchApiGroupBox.SuspendLayout();
            this.TwitchClientGroupBox.SuspendLayout();
            this.ReactionEventTab.SuspendLayout();
            this.AutoBotTab.SuspendLayout();
            this.AutoBotChildTab.SuspendLayout();
            this.TranslateTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DeepLUsageChart)).BeginInit();
            this.TimerTab.SuspendLayout();
            this.FixedNotificationGroupBox.SuspendLayout();
            this.CycleNotificationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer4NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer3NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer2NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.MainSettingTab);
            this.MenuTab.Controls.Add(this.ReactionEventTab);
            this.MenuTab.Controls.Add(this.AutoBotTab);
            this.MenuTab.Location = new System.Drawing.Point(12, 13);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.SelectedIndex = 0;
            this.MenuTab.Size = new System.Drawing.Size(776, 703);
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
            this.MainSettingTab.Size = new System.Drawing.Size(768, 677);
            this.MainSettingTab.TabIndex = 0;
            this.MainSettingTab.Text = "Main Settings";
            this.MainSettingTab.ToolTipText = "Twitch接続やTwitter送信の設定を行います。";
            this.MainSettingTab.UseVisualStyleBackColor = true;
            // 
            // ChatBoxGroupBox
            // 
            this.ChatBoxGroupBox.Location = new System.Drawing.Point(374, 7);
            this.ChatBoxGroupBox.Name = "ChatBoxGroupBox";
            this.ChatBoxGroupBox.Size = new System.Drawing.Size(388, 665);
            this.ChatBoxGroupBox.TabIndex = 2;
            this.ChatBoxGroupBox.TabStop = false;
            this.ChatBoxGroupBox.Text = "ChatBox";
            // 
            // TwitterGroupBox
            // 
            this.TwitterGroupBox.Controls.Add(this.TwitterApiButton);
            this.TwitterGroupBox.Controls.Add(this.TwitterTweetTextBox);
            this.TwitterGroupBox.Controls.Add(this.TwitterApiSecretTextBox);
            this.TwitterGroupBox.Controls.Add(this.TwitterApiKeyTextBox);
            this.TwitterGroupBox.Controls.Add(this.TwitterApiSecretLabel);
            this.TwitterGroupBox.Controls.Add(this.TwitterApiKeyLabel);
            this.TwitterGroupBox.Controls.Add(this.TwitterPushTweetButton);
            this.TwitterGroupBox.Controls.Add(this.TwitterConnectionStateLabel);
            this.TwitterGroupBox.Controls.Add(this.TwitterConnectionButton);
            this.TwitterGroupBox.Controls.Add(this.TwitterDisconnectionButton);
            this.TwitterGroupBox.Location = new System.Drawing.Point(6, 465);
            this.TwitterGroupBox.Name = "TwitterGroupBox";
            this.TwitterGroupBox.Size = new System.Drawing.Size(353, 207);
            this.TwitterGroupBox.TabIndex = 1;
            this.TwitterGroupBox.TabStop = false;
            this.TwitterGroupBox.Text = "Twitter";
            // 
            // TwitterApiButton
            // 
            this.TwitterApiButton.Location = new System.Drawing.Point(272, 66);
            this.TwitterApiButton.Name = "TwitterApiButton";
            this.TwitterApiButton.Size = new System.Drawing.Size(75, 23);
            this.TwitterApiButton.TabIndex = 12;
            this.TwitterApiButton.Text = "Twitter API";
            this.TwitterApiButton.UseVisualStyleBackColor = true;
            this.TwitterApiButton.Click += new System.EventHandler(this.TwitterApiButton_Click);
            // 
            // TwitterTweetTextBox
            // 
            this.TwitterTweetTextBox.Controls.Add(this.TwitterSendRichTextBox);
            this.TwitterTweetTextBox.Location = new System.Drawing.Point(6, 89);
            this.TwitterTweetTextBox.Name = "TwitterTweetTextBox";
            this.TwitterTweetTextBox.Size = new System.Drawing.Size(341, 81);
            this.TwitterTweetTextBox.TabIndex = 10;
            this.TwitterTweetTextBox.TabStop = false;
            this.TwitterTweetTextBox.Text = "Tweet";
            // 
            // TwitterSendRichTextBox
            // 
            this.TwitterSendRichTextBox.Location = new System.Drawing.Point(6, 20);
            this.TwitterSendRichTextBox.Name = "TwitterSendRichTextBox";
            this.TwitterSendRichTextBox.Size = new System.Drawing.Size(329, 55);
            this.TwitterSendRichTextBox.TabIndex = 4;
            this.TwitterSendRichTextBox.Text = "test\n\n@game_Fara";
            // 
            // TwitterApiSecretTextBox
            // 
            this.TwitterApiSecretTextBox.Location = new System.Drawing.Point(112, 40);
            this.TwitterApiSecretTextBox.Name = "TwitterApiSecretTextBox";
            this.TwitterApiSecretTextBox.PasswordChar = '●';
            this.TwitterApiSecretTextBox.Size = new System.Drawing.Size(235, 20);
            this.TwitterApiSecretTextBox.TabIndex = 9;
            // 
            // TwitterApiKeyTextBox
            // 
            this.TwitterApiKeyTextBox.Location = new System.Drawing.Point(112, 13);
            this.TwitterApiKeyTextBox.Name = "TwitterApiKeyTextBox";
            this.TwitterApiKeyTextBox.PasswordChar = '●';
            this.TwitterApiKeyTextBox.Size = new System.Drawing.Size(235, 20);
            this.TwitterApiKeyTextBox.TabIndex = 8;
            // 
            // TwitterApiSecretLabel
            // 
            this.TwitterApiSecretLabel.Location = new System.Drawing.Point(6, 40);
            this.TwitterApiSecretLabel.Name = "TwitterApiSecretLabel";
            this.TwitterApiSecretLabel.Size = new System.Drawing.Size(100, 17);
            this.TwitterApiSecretLabel.TabIndex = 7;
            this.TwitterApiSecretLabel.Text = "API Secret";
            this.TwitterApiSecretLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitterApiKeyLabel
            // 
            this.TwitterApiKeyLabel.Location = new System.Drawing.Point(6, 16);
            this.TwitterApiKeyLabel.Name = "TwitterApiKeyLabel";
            this.TwitterApiKeyLabel.Size = new System.Drawing.Size(100, 17);
            this.TwitterApiKeyLabel.TabIndex = 6;
            this.TwitterApiKeyLabel.Text = "API Key";
            this.TwitterApiKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitterPushTweetButton
            // 
            this.TwitterPushTweetButton.Enabled = false;
            this.TwitterPushTweetButton.Location = new System.Drawing.Point(112, 176);
            this.TwitterPushTweetButton.Name = "TwitterPushTweetButton";
            this.TwitterPushTweetButton.Size = new System.Drawing.Size(75, 25);
            this.TwitterPushTweetButton.TabIndex = 5;
            this.TwitterPushTweetButton.Text = "Tweet";
            this.TwitterPushTweetButton.UseVisualStyleBackColor = true;
            this.TwitterPushTweetButton.Click += new System.EventHandler(this.TwitterPushTweetButton_Click);
            // 
            // TwitterConnectionStateLabel
            // 
            this.TwitterConnectionStateLabel.Location = new System.Drawing.Point(3, 181);
            this.TwitterConnectionStateLabel.Name = "TwitterConnectionStateLabel";
            this.TwitterConnectionStateLabel.Size = new System.Drawing.Size(103, 16);
            this.TwitterConnectionStateLabel.TabIndex = 3;
            this.TwitterConnectionStateLabel.Text = "State: Disconnect";
            this.TwitterConnectionStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitterConnectionButton
            // 
            this.TwitterConnectionButton.Location = new System.Drawing.Point(193, 176);
            this.TwitterConnectionButton.Name = "TwitterConnectionButton";
            this.TwitterConnectionButton.Size = new System.Drawing.Size(75, 25);
            this.TwitterConnectionButton.TabIndex = 0;
            this.TwitterConnectionButton.Text = "Connect";
            this.TwitterConnectionButton.UseVisualStyleBackColor = true;
            this.TwitterConnectionButton.Click += new System.EventHandler(this.TwitterConnectionButton_Click);
            // 
            // TwitterDisconnectionButton
            // 
            this.TwitterDisconnectionButton.Location = new System.Drawing.Point(272, 176);
            this.TwitterDisconnectionButton.Name = "TwitterDisconnectionButton";
            this.TwitterDisconnectionButton.Size = new System.Drawing.Size(75, 25);
            this.TwitterDisconnectionButton.TabIndex = 1;
            this.TwitterDisconnectionButton.Text = "Disconnect";
            this.TwitterDisconnectionButton.UseVisualStyleBackColor = true;
            this.TwitterDisconnectionButton.Click += new System.EventHandler(this.TwitterDisconnectionButton_Click);
            // 
            // TwitchGroupBox
            // 
            this.TwitchGroupBox.Controls.Add(this.TwitchApiGroupBox);
            this.TwitchGroupBox.Controls.Add(this.TwitchClientGroupBox);
            this.TwitchGroupBox.Controls.Add(this.BouyomiChanConnectCheckBox);
            this.TwitchGroupBox.Controls.Add(this.TwitchConnectionStateLabel);
            this.TwitchGroupBox.Controls.Add(this.TwitchDisconnectButton);
            this.TwitchGroupBox.Controls.Add(this.TwitchConnectionButton);
            this.TwitchGroupBox.Location = new System.Drawing.Point(6, 7);
            this.TwitchGroupBox.Name = "TwitchGroupBox";
            this.TwitchGroupBox.Size = new System.Drawing.Size(353, 358);
            this.TwitchGroupBox.TabIndex = 0;
            this.TwitchGroupBox.TabStop = false;
            this.TwitchGroupBox.Text = "Twitch";
            // 
            // TwitchApiGroupBox
            // 
            this.TwitchApiGroupBox.Controls.Add(this.TwitchApiAuthorizeButton);
            this.TwitchApiGroupBox.Controls.Add(this.TwitchApiClientSecretTextBox);
            this.TwitchApiGroupBox.Controls.Add(this.TwitchApiClientSecretLabel);
            this.TwitchApiGroupBox.Controls.Add(this.TwitchApiClientIdTextBox);
            this.TwitchApiGroupBox.Controls.Add(this.TwitchApiClientIdLabel);
            this.TwitchApiGroupBox.Location = new System.Drawing.Point(6, 126);
            this.TwitchApiGroupBox.Name = "TwitchApiGroupBox";
            this.TwitchApiGroupBox.Size = new System.Drawing.Size(341, 102);
            this.TwitchApiGroupBox.TabIndex = 10;
            this.TwitchApiGroupBox.TabStop = false;
            this.TwitchApiGroupBox.Text = "API";
            // 
            // TwitchApiAuthorizeButton
            // 
            this.TwitchApiAuthorizeButton.Location = new System.Drawing.Point(260, 72);
            this.TwitchApiAuthorizeButton.Name = "TwitchApiAuthorizeButton";
            this.TwitchApiAuthorizeButton.Size = new System.Drawing.Size(75, 23);
            this.TwitchApiAuthorizeButton.TabIndex = 4;
            this.TwitchApiAuthorizeButton.Text = "Authorize";
            this.TwitchApiAuthorizeButton.UseVisualStyleBackColor = true;
            this.TwitchApiAuthorizeButton.Click += new System.EventHandler(this.TwitchApiAuthorizeButton_Click);
            // 
            // TwitchApiClientSecretTextBox
            // 
            this.TwitchApiClientSecretTextBox.Location = new System.Drawing.Point(112, 46);
            this.TwitchApiClientSecretTextBox.Name = "TwitchApiClientSecretTextBox";
            this.TwitchApiClientSecretTextBox.PasswordChar = '●';
            this.TwitchApiClientSecretTextBox.Size = new System.Drawing.Size(223, 20);
            this.TwitchApiClientSecretTextBox.TabIndex = 3;
            // 
            // TwitchApiClientSecretLabel
            // 
            this.TwitchApiClientSecretLabel.Location = new System.Drawing.Point(3, 48);
            this.TwitchApiClientSecretLabel.Name = "TwitchApiClientSecretLabel";
            this.TwitchApiClientSecretLabel.Size = new System.Drawing.Size(100, 17);
            this.TwitchApiClientSecretLabel.TabIndex = 2;
            this.TwitchApiClientSecretLabel.Text = "ClientSecret";
            this.TwitchApiClientSecretLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitchApiClientIdTextBox
            // 
            this.TwitchApiClientIdTextBox.Location = new System.Drawing.Point(112, 20);
            this.TwitchApiClientIdTextBox.Name = "TwitchApiClientIdTextBox";
            this.TwitchApiClientIdTextBox.PasswordChar = '●';
            this.TwitchApiClientIdTextBox.Size = new System.Drawing.Size(223, 20);
            this.TwitchApiClientIdTextBox.TabIndex = 1;
            // 
            // TwitchApiClientIdLabel
            // 
            this.TwitchApiClientIdLabel.Location = new System.Drawing.Point(3, 22);
            this.TwitchApiClientIdLabel.Name = "TwitchApiClientIdLabel";
            this.TwitchApiClientIdLabel.Size = new System.Drawing.Size(100, 17);
            this.TwitchApiClientIdLabel.TabIndex = 0;
            this.TwitchApiClientIdLabel.Text = "ClientId";
            this.TwitchApiClientIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitchClientGroupBox
            // 
            this.TwitchClientGroupBox.Controls.Add(this.TwitchClientAccessTokenButton);
            this.TwitchClientGroupBox.Controls.Add(this.TwitchClientUserNameLabel);
            this.TwitchClientGroupBox.Controls.Add(this.TwitchClientAccessTokenLabel);
            this.TwitchClientGroupBox.Controls.Add(this.TwitchClientUserNameTextBox);
            this.TwitchClientGroupBox.Controls.Add(this.TwitchClientAccessTokenTextBox);
            this.TwitchClientGroupBox.Location = new System.Drawing.Point(6, 17);
            this.TwitchClientGroupBox.Name = "TwitchClientGroupBox";
            this.TwitchClientGroupBox.Size = new System.Drawing.Size(341, 102);
            this.TwitchClientGroupBox.TabIndex = 0;
            this.TwitchClientGroupBox.TabStop = false;
            this.TwitchClientGroupBox.Text = "Client";
            // 
            // TwitchClientAccessTokenButton
            // 
            this.TwitchClientAccessTokenButton.Location = new System.Drawing.Point(260, 68);
            this.TwitchClientAccessTokenButton.Name = "TwitchClientAccessTokenButton";
            this.TwitchClientAccessTokenButton.Size = new System.Drawing.Size(75, 25);
            this.TwitchClientAccessTokenButton.TabIndex = 7;
            this.TwitchClientAccessTokenButton.Text = "Get Token";
            this.TwitchClientAccessTokenButton.UseVisualStyleBackColor = true;
            this.TwitchClientAccessTokenButton.Click += new System.EventHandler(this.TwitchAccessTokenButton_Click);
            // 
            // TwitchClientUserNameLabel
            // 
            this.TwitchClientUserNameLabel.Location = new System.Drawing.Point(3, 16);
            this.TwitchClientUserNameLabel.Name = "TwitchClientUserNameLabel";
            this.TwitchClientUserNameLabel.Size = new System.Drawing.Size(100, 17);
            this.TwitchClientUserNameLabel.TabIndex = 0;
            this.TwitchClientUserNameLabel.Text = "UserName";
            this.TwitchClientUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitchClientAccessTokenLabel
            // 
            this.TwitchClientAccessTokenLabel.Location = new System.Drawing.Point(3, 42);
            this.TwitchClientAccessTokenLabel.Name = "TwitchClientAccessTokenLabel";
            this.TwitchClientAccessTokenLabel.Size = new System.Drawing.Size(100, 17);
            this.TwitchClientAccessTokenLabel.TabIndex = 1;
            this.TwitchClientAccessTokenLabel.Text = "AccessToken";
            this.TwitchClientAccessTokenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TwitchClientUserNameTextBox
            // 
            this.TwitchClientUserNameTextBox.Location = new System.Drawing.Point(112, 15);
            this.TwitchClientUserNameTextBox.Name = "TwitchClientUserNameTextBox";
            this.TwitchClientUserNameTextBox.Size = new System.Drawing.Size(223, 20);
            this.TwitchClientUserNameTextBox.TabIndex = 2;
            // 
            // TwitchClientAccessTokenTextBox
            // 
            this.TwitchClientAccessTokenTextBox.Location = new System.Drawing.Point(112, 41);
            this.TwitchClientAccessTokenTextBox.Name = "TwitchClientAccessTokenTextBox";
            this.TwitchClientAccessTokenTextBox.PasswordChar = '●';
            this.TwitchClientAccessTokenTextBox.Size = new System.Drawing.Size(223, 20);
            this.TwitchClientAccessTokenTextBox.TabIndex = 3;
            // 
            // BouyomiChanConnectCheckBox
            // 
            this.BouyomiChanConnectCheckBox.Checked = true;
            this.BouyomiChanConnectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BouyomiChanConnectCheckBox.Location = new System.Drawing.Point(6, 303);
            this.BouyomiChanConnectCheckBox.Name = "BouyomiChanConnectCheckBox";
            this.BouyomiChanConnectCheckBox.Size = new System.Drawing.Size(146, 27);
            this.BouyomiChanConnectCheckBox.TabIndex = 9;
            this.BouyomiChanConnectCheckBox.Text = "BouyomiChanConnect";
            this.BouyomiChanConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // TwitchConnectionStateLabel
            // 
            this.TwitchConnectionStateLabel.Location = new System.Drawing.Point(3, 333);
            this.TwitchConnectionStateLabel.Name = "TwitchConnectionStateLabel";
            this.TwitchConnectionStateLabel.Size = new System.Drawing.Size(100, 14);
            this.TwitchConnectionStateLabel.TabIndex = 6;
            this.TwitchConnectionStateLabel.Text = "State: Disconnect";
            // 
            // TwitchDisconnectButton
            // 
            this.TwitchDisconnectButton.Enabled = false;
            this.TwitchDisconnectButton.Location = new System.Drawing.Point(272, 327);
            this.TwitchDisconnectButton.Name = "TwitchDisconnectButton";
            this.TwitchDisconnectButton.Size = new System.Drawing.Size(75, 25);
            this.TwitchDisconnectButton.TabIndex = 5;
            this.TwitchDisconnectButton.Text = "Disconnect";
            this.TwitchDisconnectButton.UseVisualStyleBackColor = true;
            this.TwitchDisconnectButton.Click += new System.EventHandler(this.TwitchDisconnectButton_Click);
            // 
            // TwitchConnectionButton
            // 
            this.TwitchConnectionButton.Enabled = false;
            this.TwitchConnectionButton.Location = new System.Drawing.Point(191, 327);
            this.TwitchConnectionButton.Name = "TwitchConnectionButton";
            this.TwitchConnectionButton.Size = new System.Drawing.Size(75, 25);
            this.TwitchConnectionButton.TabIndex = 4;
            this.TwitchConnectionButton.Text = "Connect";
            this.TwitchConnectionButton.UseVisualStyleBackColor = true;
            this.TwitchConnectionButton.Click += new System.EventHandler(this.TwitchConnectionButton_Click);
            // 
            // ReactionEventTab
            // 
            this.ReactionEventTab.Controls.Add(this.ChannelPointCheckBox);
            this.ReactionEventTab.Controls.Add(this.GiftCheckBox);
            this.ReactionEventTab.Controls.Add(this.BitsCheckBox);
            this.ReactionEventTab.Controls.Add(this.SubscriptionCheckBox);
            this.ReactionEventTab.Controls.Add(this.RaidCheckBox);
            this.ReactionEventTab.Controls.Add(this.FollowCheckBox);
            this.ReactionEventTab.Controls.Add(this.ChannelPointTestButton);
            this.ReactionEventTab.Controls.Add(this.ChannelPointEventTextBox);
            this.ReactionEventTab.Controls.Add(this.GiftTestButton);
            this.ReactionEventTab.Controls.Add(this.BitsTestButton);
            this.ReactionEventTab.Controls.Add(this.SubscriptionTestButton);
            this.ReactionEventTab.Controls.Add(this.RaidTestButton);
            this.ReactionEventTab.Controls.Add(this.FollowTestButton);
            this.ReactionEventTab.Controls.Add(this.GiftEventTextBox);
            this.ReactionEventTab.Controls.Add(this.ReplaceNotificationTextBox);
            this.ReactionEventTab.Controls.Add(this.BitsEventTextBox);
            this.ReactionEventTab.Controls.Add(this.SubscriptionEventTextBox);
            this.ReactionEventTab.Controls.Add(this.RaidEventTextBox);
            this.ReactionEventTab.Controls.Add(this.FollowEventTextBox);
            this.ReactionEventTab.Location = new System.Drawing.Point(4, 22);
            this.ReactionEventTab.Name = "ReactionEventTab";
            this.ReactionEventTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReactionEventTab.Size = new System.Drawing.Size(768, 677);
            this.ReactionEventTab.TabIndex = 1;
            this.ReactionEventTab.Text = "Reaction Event";
            this.ReactionEventTab.ToolTipText = "TwitchでFollowやRaid等のアクションに応じた設定を行います。";
            this.ReactionEventTab.UseVisualStyleBackColor = true;
            // 
            // ChannelPointCheckBox
            // 
            this.ChannelPointCheckBox.Checked = true;
            this.ChannelPointCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChannelPointCheckBox.Location = new System.Drawing.Point(6, 142);
            this.ChannelPointCheckBox.Name = "ChannelPointCheckBox";
            this.ChannelPointCheckBox.Size = new System.Drawing.Size(93, 21);
            this.ChannelPointCheckBox.TabIndex = 39;
            this.ChannelPointCheckBox.Text = "ChannelPoint";
            this.ChannelPointCheckBox.UseVisualStyleBackColor = true;
            // 
            // GiftCheckBox
            // 
            this.GiftCheckBox.Checked = true;
            this.GiftCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GiftCheckBox.Location = new System.Drawing.Point(6, 115);
            this.GiftCheckBox.Name = "GiftCheckBox";
            this.GiftCheckBox.Size = new System.Drawing.Size(93, 21);
            this.GiftCheckBox.TabIndex = 38;
            this.GiftCheckBox.Text = "Gift";
            this.GiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // BitsCheckBox
            // 
            this.BitsCheckBox.Checked = true;
            this.BitsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BitsCheckBox.Location = new System.Drawing.Point(6, 88);
            this.BitsCheckBox.Name = "BitsCheckBox";
            this.BitsCheckBox.Size = new System.Drawing.Size(93, 21);
            this.BitsCheckBox.TabIndex = 37;
            this.BitsCheckBox.Text = "Bits";
            this.BitsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SubscriptionCheckBox
            // 
            this.SubscriptionCheckBox.Checked = true;
            this.SubscriptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SubscriptionCheckBox.Location = new System.Drawing.Point(6, 61);
            this.SubscriptionCheckBox.Name = "SubscriptionCheckBox";
            this.SubscriptionCheckBox.Size = new System.Drawing.Size(93, 21);
            this.SubscriptionCheckBox.TabIndex = 36;
            this.SubscriptionCheckBox.Text = "Subscription";
            this.SubscriptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // RaidCheckBox
            // 
            this.RaidCheckBox.Checked = true;
            this.RaidCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RaidCheckBox.Location = new System.Drawing.Point(6, 34);
            this.RaidCheckBox.Name = "RaidCheckBox";
            this.RaidCheckBox.Size = new System.Drawing.Size(93, 21);
            this.RaidCheckBox.TabIndex = 35;
            this.RaidCheckBox.Text = "Raid";
            this.RaidCheckBox.UseVisualStyleBackColor = true;
            // 
            // FollowCheckBox
            // 
            this.FollowCheckBox.Checked = true;
            this.FollowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FollowCheckBox.Location = new System.Drawing.Point(6, 7);
            this.FollowCheckBox.Name = "FollowCheckBox";
            this.FollowCheckBox.Size = new System.Drawing.Size(93, 21);
            this.FollowCheckBox.TabIndex = 34;
            this.FollowCheckBox.Text = "Follow";
            this.FollowCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChannelPointTestButton
            // 
            this.ChannelPointTestButton.Location = new System.Drawing.Point(711, 142);
            this.ChannelPointTestButton.Name = "ChannelPointTestButton";
            this.ChannelPointTestButton.Size = new System.Drawing.Size(51, 21);
            this.ChannelPointTestButton.TabIndex = 30;
            this.ChannelPointTestButton.Text = "Test";
            this.ChannelPointTestButton.UseVisualStyleBackColor = true;
            // 
            // ChannelPointEventTextBox
            // 
            this.ChannelPointEventTextBox.Location = new System.Drawing.Point(105, 142);
            this.ChannelPointEventTextBox.Name = "ChannelPointEventTextBox";
            this.ChannelPointEventTextBox.Size = new System.Drawing.Size(600, 20);
            this.ChannelPointEventTextBox.TabIndex = 29;
            this.ChannelPointEventTextBox.Text = "{channelPointUserName} use channelPoint of {channelPointTitle} gamefa16Hi";
            // 
            // GiftTestButton
            // 
            this.GiftTestButton.Location = new System.Drawing.Point(711, 115);
            this.GiftTestButton.Name = "GiftTestButton";
            this.GiftTestButton.Size = new System.Drawing.Size(51, 21);
            this.GiftTestButton.TabIndex = 26;
            this.GiftTestButton.Text = "Test";
            this.GiftTestButton.UseVisualStyleBackColor = true;
            // 
            // BitsTestButton
            // 
            this.BitsTestButton.Location = new System.Drawing.Point(711, 88);
            this.BitsTestButton.Name = "BitsTestButton";
            this.BitsTestButton.Size = new System.Drawing.Size(51, 21);
            this.BitsTestButton.TabIndex = 25;
            this.BitsTestButton.Text = "Test";
            this.BitsTestButton.UseVisualStyleBackColor = true;
            // 
            // SubscriptionTestButton
            // 
            this.SubscriptionTestButton.Location = new System.Drawing.Point(711, 61);
            this.SubscriptionTestButton.Name = "SubscriptionTestButton";
            this.SubscriptionTestButton.Size = new System.Drawing.Size(51, 21);
            this.SubscriptionTestButton.TabIndex = 24;
            this.SubscriptionTestButton.Text = "Test";
            this.SubscriptionTestButton.UseVisualStyleBackColor = true;
            // 
            // RaidTestButton
            // 
            this.RaidTestButton.Location = new System.Drawing.Point(711, 34);
            this.RaidTestButton.Name = "RaidTestButton";
            this.RaidTestButton.Size = new System.Drawing.Size(51, 21);
            this.RaidTestButton.TabIndex = 23;
            this.RaidTestButton.Text = "Test";
            this.RaidTestButton.UseVisualStyleBackColor = true;
            // 
            // FollowTestButton
            // 
            this.FollowTestButton.Location = new System.Drawing.Point(711, 7);
            this.FollowTestButton.Name = "FollowTestButton";
            this.FollowTestButton.Size = new System.Drawing.Size(51, 21);
            this.FollowTestButton.TabIndex = 22;
            this.FollowTestButton.Text = "Test";
            this.FollowTestButton.UseVisualStyleBackColor = true;
            this.FollowTestButton.Click += new System.EventHandler(this.FollowTestButton_Click);
            // 
            // GiftEventTextBox
            // 
            this.GiftEventTextBox.Location = new System.Drawing.Point(105, 115);
            this.GiftEventTextBox.Name = "GiftEventTextBox";
            this.GiftEventTextBox.Size = new System.Drawing.Size(600, 20);
            this.GiftEventTextBox.TabIndex = 21;
            this.GiftEventTextBox.Text = "{giftedUserName}, thanks gift present gamefa16Hi";
            // 
            // ReplaceNotificationTextBox
            // 
            this.ReplaceNotificationTextBox.Location = new System.Drawing.Point(6, 169);
            this.ReplaceNotificationTextBox.Multiline = true;
            this.ReplaceNotificationTextBox.Name = "ReplaceNotificationTextBox";
            this.ReplaceNotificationTextBox.ReadOnly = true;
            this.ReplaceNotificationTextBox.Size = new System.Drawing.Size(756, 472);
            this.ReplaceNotificationTextBox.TabIndex = 19;
            this.ReplaceNotificationTextBox.Text = resources.GetString("ReplaceNotificationTextBox.Text");
            // 
            // BitsEventTextBox
            // 
            this.BitsEventTextBox.Location = new System.Drawing.Point(105, 88);
            this.BitsEventTextBox.Name = "BitsEventTextBox";
            this.BitsEventTextBox.Size = new System.Drawing.Size(600, 20);
            this.BitsEventTextBox.TabIndex = 17;
            this.BitsEventTextBox.Text = "{bitsSendUserName}, thanks {bitsAmount} bits (total {totalBitsAmount}) gamefa16Hi" +
                                         "";
            // 
            // SubscriptionEventTextBox
            // 
            this.SubscriptionEventTextBox.Location = new System.Drawing.Point(105, 61);
            this.SubscriptionEventTextBox.Name = "SubscriptionEventTextBox";
            this.SubscriptionEventTextBox.Size = new System.Drawing.Size(600, 20);
            this.SubscriptionEventTextBox.TabIndex = 16;
            this.SubscriptionEventTextBox.Text = "{subscriberName}, thanks subscription {totalSubscriptionMonth} time gamefa16Hi";
            // 
            // RaidEventTextBox
            // 
            this.RaidEventTextBox.Location = new System.Drawing.Point(105, 34);
            this.RaidEventTextBox.Name = "RaidEventTextBox";
            this.RaidEventTextBox.Size = new System.Drawing.Size(600, 20);
            this.RaidEventTextBox.TabIndex = 14;
            this.RaidEventTextBox.Text = "Welcome raiders, thanks raid {raiderName} gamefa16Hi. Channel URL: {raiderChannel" +
                                         "Url}";
            // 
            // FollowEventTextBox
            // 
            this.FollowEventTextBox.Location = new System.Drawing.Point(105, 7);
            this.FollowEventTextBox.Name = "FollowEventTextBox";
            this.FollowEventTextBox.Size = new System.Drawing.Size(600, 20);
            this.FollowEventTextBox.TabIndex = 12;
            this.FollowEventTextBox.Text = "{followerName}, thanks follow gamefa16Hi. Channel URL: {followerChannelUrl}";
            // 
            // AutoBotTab
            // 
            this.AutoBotTab.Controls.Add(this.AutoBotChildTab);
            this.AutoBotTab.Location = new System.Drawing.Point(4, 22);
            this.AutoBotTab.Name = "AutoBotTab";
            this.AutoBotTab.Size = new System.Drawing.Size(768, 677);
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
            this.AutoBotChildTab.Size = new System.Drawing.Size(762, 668);
            this.AutoBotChildTab.TabIndex = 0;
            // 
            // TranslateTab
            // 
            this.TranslateTab.Controls.Add(this.DeepLCautionLabel);
            this.TranslateTab.Controls.Add(this.DeepLApiKeyTextBox);
            this.TranslateTab.Controls.Add(this.DeepLApiKeyLabel);
            this.TranslateTab.Controls.Add(this.DeepLUsageChart);
            this.TranslateTab.Location = new System.Drawing.Point(4, 22);
            this.TranslateTab.Name = "TranslateTab";
            this.TranslateTab.Padding = new System.Windows.Forms.Padding(3);
            this.TranslateTab.Size = new System.Drawing.Size(754, 642);
            this.TranslateTab.TabIndex = 0;
            this.TranslateTab.Text = "Translate";
            this.TranslateTab.ToolTipText = "チャット翻訳設定を行います。";
            this.TranslateTab.UseVisualStyleBackColor = true;
            // 
            // DeepLCautionLabel
            // 
            this.DeepLCautionLabel.ForeColor = System.Drawing.Color.Red;
            this.DeepLCautionLabel.Location = new System.Drawing.Point(6, 51);
            this.DeepLCautionLabel.Name = "DeepLCautionLabel";
            this.DeepLCautionLabel.Size = new System.Drawing.Size(742, 22);
            this.DeepLCautionLabel.TabIndex = 3;
            this.DeepLCautionLabel.Text = "※Enter a Key for either DeepL API Free or Pro";
            this.DeepLCautionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeepLApiKeyTextBox
            // 
            this.DeepLApiKeyTextBox.Location = new System.Drawing.Point(102, 15);
            this.DeepLApiKeyTextBox.Name = "DeepLApiKeyTextBox";
            this.DeepLApiKeyTextBox.PasswordChar = '●';
            this.DeepLApiKeyTextBox.Size = new System.Drawing.Size(646, 20);
            this.DeepLApiKeyTextBox.TabIndex = 1;
            // 
            // DeepLApiKeyLabel
            // 
            this.DeepLApiKeyLabel.Location = new System.Drawing.Point(6, 13);
            this.DeepLApiKeyLabel.Name = "DeepLApiKeyLabel";
            this.DeepLApiKeyLabel.Size = new System.Drawing.Size(90, 25);
            this.DeepLApiKeyLabel.TabIndex = 0;
            this.DeepLApiKeyLabel.Text = "DeepL API Key";
            this.DeepLApiKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeepLUsageChart
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalOffset = 1D;
            chartArea1.Name = "ChartArea1";
            this.DeepLUsageChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DeepLUsageChart.Legends.Add(legend1);
            this.DeepLUsageChart.Location = new System.Drawing.Point(6, 76);
            this.DeepLUsageChart.Name = "DeepLUsageChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Characters";
            this.DeepLUsageChart.Series.Add(series1);
            this.DeepLUsageChart.Size = new System.Drawing.Size(742, 558);
            this.DeepLUsageChart.TabIndex = 2;
            this.DeepLUsageChart.Text = "chart1";
            // 
            // TimerTab
            // 
            this.TimerTab.Controls.Add(this.FixedNotificationGroupBox);
            this.TimerTab.Controls.Add(this.CycleNotificationGroupBox);
            this.TimerTab.Location = new System.Drawing.Point(4, 22);
            this.TimerTab.Name = "TimerTab";
            this.TimerTab.Padding = new System.Windows.Forms.Padding(3);
            this.TimerTab.Size = new System.Drawing.Size(754, 642);
            this.TimerTab.TabIndex = 1;
            this.TimerTab.Text = "Timer";
            this.TimerTab.ToolTipText = "一定時間毎のTwitchチャット通知設定を行います。";
            this.TimerTab.UseVisualStyleBackColor = true;
            // 
            // FixedNotificationGroupBox
            // 
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer5TextBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer5CheckBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer5DateTimePicker);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer4TextBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer4CheckBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer4DateTimePicker);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer3TextBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer3CheckBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer3DateTimePicker);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer2TextBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer2CheckBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer2DateTimePicker);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer1TextBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer1CheckBox);
            this.FixedNotificationGroupBox.Controls.Add(this.FixedTimer1DateTimePicker);
            this.FixedNotificationGroupBox.Location = new System.Drawing.Point(6, 154);
            this.FixedNotificationGroupBox.Name = "FixedNotificationGroupBox";
            this.FixedNotificationGroupBox.Size = new System.Drawing.Size(742, 144);
            this.FixedNotificationGroupBox.TabIndex = 1;
            this.FixedNotificationGroupBox.TabStop = false;
            this.FixedNotificationGroupBox.Text = "Fixed Notifications";
            // 
            // FixedTimer5TextBox
            // 
            this.FixedTimer5TextBox.Location = new System.Drawing.Point(246, 118);
            this.FixedTimer5TextBox.Name = "FixedTimer5TextBox";
            this.FixedTimer5TextBox.Size = new System.Drawing.Size(490, 20);
            this.FixedTimer5TextBox.TabIndex = 14;
            // 
            // FixedTimer5CheckBox
            // 
            this.FixedTimer5CheckBox.Location = new System.Drawing.Point(6, 118);
            this.FixedTimer5CheckBox.Name = "FixedTimer5CheckBox";
            this.FixedTimer5CheckBox.Size = new System.Drawing.Size(86, 20);
            this.FixedTimer5CheckBox.TabIndex = 13;
            this.FixedTimer5CheckBox.Text = "FixedTimer5";
            this.FixedTimer5CheckBox.UseVisualStyleBackColor = true;
            // 
            // FixedTimer5DateTimePicker
            // 
            this.FixedTimer5DateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.FixedTimer5DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FixedTimer5DateTimePicker.Location = new System.Drawing.Point(98, 118);
            this.FixedTimer5DateTimePicker.Name = "FixedTimer5DateTimePicker";
            this.FixedTimer5DateTimePicker.Size = new System.Drawing.Size(142, 20);
            this.FixedTimer5DateTimePicker.TabIndex = 12;
            this.FixedTimer5DateTimePicker.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // FixedTimer4TextBox
            // 
            this.FixedTimer4TextBox.Location = new System.Drawing.Point(246, 93);
            this.FixedTimer4TextBox.Name = "FixedTimer4TextBox";
            this.FixedTimer4TextBox.Size = new System.Drawing.Size(490, 20);
            this.FixedTimer4TextBox.TabIndex = 11;
            // 
            // FixedTimer4CheckBox
            // 
            this.FixedTimer4CheckBox.Location = new System.Drawing.Point(6, 93);
            this.FixedTimer4CheckBox.Name = "FixedTimer4CheckBox";
            this.FixedTimer4CheckBox.Size = new System.Drawing.Size(86, 20);
            this.FixedTimer4CheckBox.TabIndex = 10;
            this.FixedTimer4CheckBox.Text = "FixedTimer4";
            this.FixedTimer4CheckBox.UseVisualStyleBackColor = true;
            // 
            // FixedTimer4DateTimePicker
            // 
            this.FixedTimer4DateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.FixedTimer4DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FixedTimer4DateTimePicker.Location = new System.Drawing.Point(98, 93);
            this.FixedTimer4DateTimePicker.Name = "FixedTimer4DateTimePicker";
            this.FixedTimer4DateTimePicker.Size = new System.Drawing.Size(142, 20);
            this.FixedTimer4DateTimePicker.TabIndex = 9;
            this.FixedTimer4DateTimePicker.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // FixedTimer3TextBox
            // 
            this.FixedTimer3TextBox.Location = new System.Drawing.Point(246, 68);
            this.FixedTimer3TextBox.Name = "FixedTimer3TextBox";
            this.FixedTimer3TextBox.Size = new System.Drawing.Size(490, 20);
            this.FixedTimer3TextBox.TabIndex = 8;
            // 
            // FixedTimer3CheckBox
            // 
            this.FixedTimer3CheckBox.Location = new System.Drawing.Point(6, 68);
            this.FixedTimer3CheckBox.Name = "FixedTimer3CheckBox";
            this.FixedTimer3CheckBox.Size = new System.Drawing.Size(86, 20);
            this.FixedTimer3CheckBox.TabIndex = 7;
            this.FixedTimer3CheckBox.Text = "FixedTimer3";
            this.FixedTimer3CheckBox.UseVisualStyleBackColor = true;
            // 
            // FixedTimer3DateTimePicker
            // 
            this.FixedTimer3DateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.FixedTimer3DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FixedTimer3DateTimePicker.Location = new System.Drawing.Point(98, 68);
            this.FixedTimer3DateTimePicker.Name = "FixedTimer3DateTimePicker";
            this.FixedTimer3DateTimePicker.Size = new System.Drawing.Size(142, 20);
            this.FixedTimer3DateTimePicker.TabIndex = 6;
            this.FixedTimer3DateTimePicker.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // FixedTimer2TextBox
            // 
            this.FixedTimer2TextBox.Location = new System.Drawing.Point(246, 43);
            this.FixedTimer2TextBox.Name = "FixedTimer2TextBox";
            this.FixedTimer2TextBox.Size = new System.Drawing.Size(490, 20);
            this.FixedTimer2TextBox.TabIndex = 5;
            // 
            // FixedTimer2CheckBox
            // 
            this.FixedTimer2CheckBox.Location = new System.Drawing.Point(6, 43);
            this.FixedTimer2CheckBox.Name = "FixedTimer2CheckBox";
            this.FixedTimer2CheckBox.Size = new System.Drawing.Size(86, 20);
            this.FixedTimer2CheckBox.TabIndex = 4;
            this.FixedTimer2CheckBox.Text = "FixedTimer2";
            this.FixedTimer2CheckBox.UseVisualStyleBackColor = true;
            // 
            // FixedTimer2DateTimePicker
            // 
            this.FixedTimer2DateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.FixedTimer2DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FixedTimer2DateTimePicker.Location = new System.Drawing.Point(98, 43);
            this.FixedTimer2DateTimePicker.Name = "FixedTimer2DateTimePicker";
            this.FixedTimer2DateTimePicker.Size = new System.Drawing.Size(142, 20);
            this.FixedTimer2DateTimePicker.TabIndex = 3;
            this.FixedTimer2DateTimePicker.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // FixedTimer1TextBox
            // 
            this.FixedTimer1TextBox.Location = new System.Drawing.Point(246, 18);
            this.FixedTimer1TextBox.Name = "FixedTimer1TextBox";
            this.FixedTimer1TextBox.Size = new System.Drawing.Size(490, 20);
            this.FixedTimer1TextBox.TabIndex = 2;
            // 
            // FixedTimer1CheckBox
            // 
            this.FixedTimer1CheckBox.Location = new System.Drawing.Point(6, 20);
            this.FixedTimer1CheckBox.Name = "FixedTimer1CheckBox";
            this.FixedTimer1CheckBox.Size = new System.Drawing.Size(86, 20);
            this.FixedTimer1CheckBox.TabIndex = 1;
            this.FixedTimer1CheckBox.Text = "FixedTimer1";
            this.FixedTimer1CheckBox.UseVisualStyleBackColor = true;
            // 
            // FixedTimer1DateTimePicker
            // 
            this.FixedTimer1DateTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.FixedTimer1DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FixedTimer1DateTimePicker.Location = new System.Drawing.Point(98, 18);
            this.FixedTimer1DateTimePicker.Name = "FixedTimer1DateTimePicker";
            this.FixedTimer1DateTimePicker.Size = new System.Drawing.Size(142, 20);
            this.FixedTimer1DateTimePicker.TabIndex = 0;
            this.FixedTimer1DateTimePicker.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // CycleNotificationGroupBox
            // 
            this.CycleNotificationGroupBox.Controls.Add(this.checkBox1);
            this.CycleNotificationGroupBox.Controls.Add(this.textBox2);
            this.CycleNotificationGroupBox.Controls.Add(this.label1);
            this.CycleNotificationGroupBox.Controls.Add(this.numericUpDown1);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer4CheckBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer4TextBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer4Label);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer4NumericUpDown);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer3CheckBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer3TextBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer3Label);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer3NumericUpDown);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer2CheckBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer1NumericUpDown);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer2NumericUpDown);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer2TextBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer2Label);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer1CheckBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer1TextBox);
            this.CycleNotificationGroupBox.Controls.Add(this.Timer1Label);
            this.CycleNotificationGroupBox.Location = new System.Drawing.Point(6, 3);
            this.CycleNotificationGroupBox.Name = "CycleNotificationGroupBox";
            this.CycleNotificationGroupBox.Size = new System.Drawing.Size(742, 145);
            this.CycleNotificationGroupBox.TabIndex = 0;
            this.CycleNotificationGroupBox.TabStop = false;
            this.CycleNotificationGroupBox.Text = "Cycle Notifications";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(6, 118);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 20);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Timer5";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(246, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(490, 20);
            this.textBox2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(161, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "seconds/times";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[]
            {
                5, 0, 0, 0
            });
            this.numericUpDown1.Location = new System.Drawing.Point(98, 118);
            this.numericUpDown1.Maximum = new decimal(new int[]
            {
                120, 0, 0, 0
            });
            this.numericUpDown1.Minimum = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Tag = "";
            this.numericUpDown1.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown1.Value = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            // 
            // Timer4CheckBox
            // 
            this.Timer4CheckBox.Location = new System.Drawing.Point(6, 93);
            this.Timer4CheckBox.Name = "Timer4CheckBox";
            this.Timer4CheckBox.Size = new System.Drawing.Size(62, 20);
            this.Timer4CheckBox.TabIndex = 12;
            this.Timer4CheckBox.Text = "Timer4";
            this.Timer4CheckBox.UseVisualStyleBackColor = true;
            // 
            // Timer4TextBox
            // 
            this.Timer4TextBox.Location = new System.Drawing.Point(246, 93);
            this.Timer4TextBox.Name = "Timer4TextBox";
            this.Timer4TextBox.Size = new System.Drawing.Size(490, 20);
            this.Timer4TextBox.TabIndex = 15;
            // 
            // Timer4Label
            // 
            this.Timer4Label.Location = new System.Drawing.Point(161, 93);
            this.Timer4Label.Name = "Timer4Label";
            this.Timer4Label.Size = new System.Drawing.Size(79, 20);
            this.Timer4Label.TabIndex = 14;
            this.Timer4Label.Text = "seconds/times";
            this.Timer4Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Timer4NumericUpDown
            // 
            this.Timer4NumericUpDown.Increment = new decimal(new int[]
            {
                5, 0, 0, 0
            });
            this.Timer4NumericUpDown.Location = new System.Drawing.Point(98, 93);
            this.Timer4NumericUpDown.Maximum = new decimal(new int[]
            {
                120, 0, 0, 0
            });
            this.Timer4NumericUpDown.Minimum = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            this.Timer4NumericUpDown.Name = "Timer4NumericUpDown";
            this.Timer4NumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.Timer4NumericUpDown.TabIndex = 13;
            this.Timer4NumericUpDown.Tag = "";
            this.Timer4NumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Timer4NumericUpDown.Value = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            // 
            // Timer3CheckBox
            // 
            this.Timer3CheckBox.Location = new System.Drawing.Point(6, 68);
            this.Timer3CheckBox.Name = "Timer3CheckBox";
            this.Timer3CheckBox.Size = new System.Drawing.Size(62, 20);
            this.Timer3CheckBox.TabIndex = 8;
            this.Timer3CheckBox.Text = "Timer3";
            this.Timer3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Timer3TextBox
            // 
            this.Timer3TextBox.Location = new System.Drawing.Point(246, 68);
            this.Timer3TextBox.Name = "Timer3TextBox";
            this.Timer3TextBox.Size = new System.Drawing.Size(490, 20);
            this.Timer3TextBox.TabIndex = 11;
            // 
            // Timer3Label
            // 
            this.Timer3Label.Location = new System.Drawing.Point(161, 68);
            this.Timer3Label.Name = "Timer3Label";
            this.Timer3Label.Size = new System.Drawing.Size(79, 20);
            this.Timer3Label.TabIndex = 10;
            this.Timer3Label.Text = "seconds/times";
            this.Timer3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Timer3NumericUpDown
            // 
            this.Timer3NumericUpDown.Increment = new decimal(new int[]
            {
                5, 0, 0, 0
            });
            this.Timer3NumericUpDown.Location = new System.Drawing.Point(98, 68);
            this.Timer3NumericUpDown.Maximum = new decimal(new int[]
            {
                120, 0, 0, 0
            });
            this.Timer3NumericUpDown.Minimum = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            this.Timer3NumericUpDown.Name = "Timer3NumericUpDown";
            this.Timer3NumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.Timer3NumericUpDown.TabIndex = 9;
            this.Timer3NumericUpDown.Tag = "";
            this.Timer3NumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Timer3NumericUpDown.Value = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            // 
            // Timer2CheckBox
            // 
            this.Timer2CheckBox.Location = new System.Drawing.Point(6, 43);
            this.Timer2CheckBox.Name = "Timer2CheckBox";
            this.Timer2CheckBox.Size = new System.Drawing.Size(62, 20);
            this.Timer2CheckBox.TabIndex = 4;
            this.Timer2CheckBox.Text = "Timer2";
            this.Timer2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Timer1NumericUpDown
            // 
            this.Timer1NumericUpDown.Increment = new decimal(new int[]
            {
                5, 0, 0, 0
            });
            this.Timer1NumericUpDown.Location = new System.Drawing.Point(98, 18);
            this.Timer1NumericUpDown.Maximum = new decimal(new int[]
            {
                120, 0, 0, 0
            });
            this.Timer1NumericUpDown.Minimum = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            this.Timer1NumericUpDown.Name = "Timer1NumericUpDown";
            this.Timer1NumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.Timer1NumericUpDown.TabIndex = 1;
            this.Timer1NumericUpDown.Tag = "";
            this.Timer1NumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Timer1NumericUpDown.Value = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            // 
            // Timer2NumericUpDown
            // 
            this.Timer2NumericUpDown.Increment = new decimal(new int[]
            {
                5, 0, 0, 0
            });
            this.Timer2NumericUpDown.Location = new System.Drawing.Point(98, 43);
            this.Timer2NumericUpDown.Maximum = new decimal(new int[]
            {
                120, 0, 0, 0
            });
            this.Timer2NumericUpDown.Minimum = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            this.Timer2NumericUpDown.Name = "Timer2NumericUpDown";
            this.Timer2NumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.Timer2NumericUpDown.TabIndex = 5;
            this.Timer2NumericUpDown.Tag = "";
            this.Timer2NumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Timer2NumericUpDown.Value = new decimal(new int[]
            {
                15, 0, 0, 0
            });
            // 
            // Timer2TextBox
            // 
            this.Timer2TextBox.Location = new System.Drawing.Point(246, 43);
            this.Timer2TextBox.Name = "Timer2TextBox";
            this.Timer2TextBox.Size = new System.Drawing.Size(490, 20);
            this.Timer2TextBox.TabIndex = 7;
            // 
            // Timer2Label
            // 
            this.Timer2Label.Location = new System.Drawing.Point(161, 43);
            this.Timer2Label.Name = "Timer2Label";
            this.Timer2Label.Size = new System.Drawing.Size(79, 20);
            this.Timer2Label.TabIndex = 6;
            this.Timer2Label.Text = "seconds/times";
            this.Timer2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Timer1CheckBox
            // 
            this.Timer1CheckBox.Location = new System.Drawing.Point(6, 18);
            this.Timer1CheckBox.Name = "Timer1CheckBox";
            this.Timer1CheckBox.Size = new System.Drawing.Size(62, 20);
            this.Timer1CheckBox.TabIndex = 0;
            this.Timer1CheckBox.Text = "Timer1";
            this.Timer1CheckBox.UseVisualStyleBackColor = true;
            // 
            // Timer1TextBox
            // 
            this.Timer1TextBox.Location = new System.Drawing.Point(246, 18);
            this.Timer1TextBox.Name = "Timer1TextBox";
            this.Timer1TextBox.Size = new System.Drawing.Size(490, 20);
            this.Timer1TextBox.TabIndex = 3;
            // 
            // Timer1Label
            // 
            this.Timer1Label.Location = new System.Drawing.Point(161, 18);
            this.Timer1Label.Name = "Timer1Label";
            this.Timer1Label.Size = new System.Drawing.Size(79, 20);
            this.Timer1Label.TabIndex = 2;
            this.Timer1Label.Text = "seconds/times";
            this.Timer1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FaraBotModeratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 729);
            this.Controls.Add(this.MenuTab);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "FaraBotModeratorForm";
            this.Text = "FaraBotModerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaraBotModeratorForm_FormClosing);
            this.MenuTab.ResumeLayout(false);
            this.MainSettingTab.ResumeLayout(false);
            this.TwitterGroupBox.ResumeLayout(false);
            this.TwitterGroupBox.PerformLayout();
            this.TwitterTweetTextBox.ResumeLayout(false);
            this.TwitchGroupBox.ResumeLayout(false);
            this.TwitchApiGroupBox.ResumeLayout(false);
            this.TwitchApiGroupBox.PerformLayout();
            this.TwitchClientGroupBox.ResumeLayout(false);
            this.TwitchClientGroupBox.PerformLayout();
            this.ReactionEventTab.ResumeLayout(false);
            this.ReactionEventTab.PerformLayout();
            this.AutoBotTab.ResumeLayout(false);
            this.AutoBotChildTab.ResumeLayout(false);
            this.TranslateTab.ResumeLayout(false);
            this.TranslateTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DeepLUsageChart)).EndInit();
            this.TimerTab.ResumeLayout(false);
            this.FixedNotificationGroupBox.ResumeLayout(false);
            this.FixedNotificationGroupBox.PerformLayout();
            this.CycleNotificationGroupBox.ResumeLayout(false);
            this.CycleNotificationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer4NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer3NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.Timer2NumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label DeepLCautionLabel;

        private System.Windows.Forms.DataVisualization.Charting.Chart DeepLUsageChart;

        private System.Windows.Forms.CheckBox ChannelPointCheckBox;

        private System.Windows.Forms.CheckBox FollowCheckBox;
        private System.Windows.Forms.CheckBox RaidCheckBox;
        private System.Windows.Forms.CheckBox SubscriptionCheckBox;
        private System.Windows.Forms.CheckBox BitsCheckBox;
        private System.Windows.Forms.CheckBox GiftCheckBox;

        private System.Windows.Forms.Button ChannelPointTestButton;
        private System.Windows.Forms.TextBox ChannelPointEventTextBox;

        private System.Windows.Forms.Button TwitchApiAuthorizeButton;

        private System.Windows.Forms.TextBox FixedTimer4TextBox;
        private System.Windows.Forms.CheckBox FixedTimer4CheckBox;
        private System.Windows.Forms.DateTimePicker FixedTimer4DateTimePicker;
        private System.Windows.Forms.TextBox FixedTimer5TextBox;
        private System.Windows.Forms.CheckBox FixedTimer5CheckBox;
        private System.Windows.Forms.DateTimePicker FixedTimer5DateTimePicker;

        private System.Windows.Forms.TextBox FixedTimer3TextBox;
        private System.Windows.Forms.CheckBox FixedTimer3CheckBox;
        private System.Windows.Forms.DateTimePicker FixedTimer3DateTimePicker;

        private System.Windows.Forms.TextBox FixedTimer2TextBox;
        private System.Windows.Forms.CheckBox FixedTimer2CheckBox;
        private System.Windows.Forms.DateTimePicker FixedTimer2DateTimePicker;

        private System.Windows.Forms.CheckBox Timer4CheckBox;
        private System.Windows.Forms.TextBox Timer4TextBox;
        private System.Windows.Forms.Label Timer4Label;
        private System.Windows.Forms.NumericUpDown Timer4NumericUpDown;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;

        private System.Windows.Forms.TextBox FixedTimer1TextBox;

        private System.Windows.Forms.CheckBox FixedTimer1CheckBox;

        private System.Windows.Forms.DateTimePicker FixedTimer1DateTimePicker;

        private System.Windows.Forms.TextBox Timer1TextBox;
        private System.Windows.Forms.CheckBox Timer3CheckBox;
        private System.Windows.Forms.Label Timer3Label;
        private System.Windows.Forms.NumericUpDown Timer3NumericUpDown;

        private System.Windows.Forms.Button TwitterApiButton;

        private System.Windows.Forms.Label TwitchApiClientSecretLabel;
        private System.Windows.Forms.TextBox TwitchApiClientSecretTextBox;

        private System.Windows.Forms.TextBox TwitchApiClientIdTextBox;

        private System.Windows.Forms.GroupBox TwitchApiGroupBox;
        private System.Windows.Forms.Label TwitchApiClientIdLabel;

        private System.Windows.Forms.GroupBox TwitchClientGroupBox;

        private System.Windows.Forms.CheckBox BouyomiChanConnectCheckBox;

        private System.Windows.Forms.TextBox Timer3TextBox;
        private System.Windows.Forms.TextBox Timer2TextBox;
        private System.Windows.Forms.Label Timer2Label;
        private System.Windows.Forms.NumericUpDown Timer2NumericUpDown;
        private System.Windows.Forms.CheckBox Timer1CheckBox;
        private System.Windows.Forms.CheckBox Timer2CheckBox;

        private System.Windows.Forms.Label Timer1Label;

        private System.Windows.Forms.NumericUpDown Timer1NumericUpDown;

        private System.Windows.Forms.Button FollowTestButton;
        private System.Windows.Forms.Button RaidTestButton;
        private System.Windows.Forms.Button SubscriptionTestButton;
        private System.Windows.Forms.Button BitsTestButton;
        private System.Windows.Forms.Button GiftTestButton;

        private System.Windows.Forms.TextBox GiftEventTextBox;

        private System.Windows.Forms.TextBox ReplaceNotificationTextBox;

        private System.Windows.Forms.TextBox BitsEventTextBox;

        private System.Windows.Forms.TextBox SubscriptionEventTextBox;

        private System.Windows.Forms.TextBox RaidEventTextBox;

        private System.Windows.Forms.TextBox FollowEventTextBox;

        private System.Windows.Forms.GroupBox CycleNotificationGroupBox;

        private System.Windows.Forms.GroupBox FixedNotificationGroupBox;

        private System.Windows.Forms.TextBox DeepLApiKeyTextBox;

        private System.Windows.Forms.Label DeepLApiKeyLabel;

        private System.Windows.Forms.GroupBox TwitterTweetTextBox;

        private System.Windows.Forms.TextBox TwitterApiKeyTextBox;
        private System.Windows.Forms.TextBox TwitterApiSecretTextBox;

        private System.Windows.Forms.Label TwitterApiKeyLabel;

        private System.Windows.Forms.Label TwitterApiSecretLabel;

        private System.Windows.Forms.Button TwitchClientAccessTokenButton;

        private System.Windows.Forms.GroupBox ChatBoxGroupBox;

        private System.Windows.Forms.Button TwitterPushTweetButton;

        private System.Windows.Forms.RichTextBox TwitterSendRichTextBox;

        private System.Windows.Forms.Button TwitterConnectionButton;
        private System.Windows.Forms.Label TwitterConnectionStateLabel;

        private System.Windows.Forms.Button TwitterDisconnectionButton;

        private System.Windows.Forms.GroupBox TwitterGroupBox;

        private System.Windows.Forms.Label TwitchConnectionStateLabel;

        public System.Windows.Forms.TextBox TwitchClientUserNameTextBox;

        private System.Windows.Forms.Label TwitchClientAccessTokenLabel;

        private System.Windows.Forms.TextBox TwitchClientAccessTokenTextBox;

        private System.Windows.Forms.Label TwitchClientUserNameLabel;

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