﻿using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FaraBotModerator.controllers;
using FaraBotModerator.models;
using FaraBotModerator.Properties;
using Microsoft.Web.WebView2.Core;

namespace FaraBotModerator.views;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    /// <summary>
    /// </summary>
    private ChatWindow? _chatWindow;

    /// <summary>
    /// </summary>
    private TwitchApiController? _twitchApiController;

    /// <summary>
    /// </summary>
    private TwitchClientController? _twitchClientController;

    /// <summary>
    /// </summary>
    private TwitchPubSubController? _twitchPubSubController;

    /// <summary>
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        InitializeEncodeRegister();
        InitializeSecretValue();
        InitializeChatWindow();
        // Task
        StartTimer();
        StartWebServer();
        StartMonitoring();
        StartTwitchLibPubSub();
    }

    /// <summary>
    ///     Windowsが提供するEncodingを利用できるようにする。SHIFT-JIS等も使用可能になる。
    /// </summary>
    private void InitializeEncodeRegister()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    private void InitializeSecretValue()
    {
        var secretKeys = SecretKeyController.LoadKeys();
        TwitchClientUserNameTextBox.Text = secretKeys.Twitch.Client.UserName;
        TwitchClientAccessTokenPasswordBox.Password = secretKeys.Twitch.Client.AccessToken;
        TwitchClientDisplayNameTextBox.Text = secretKeys.Twitch.Client.DisplayName;

        TwitchApiClientIdPasswordBox.Password = secretKeys.Twitch.Api.ClientId;
        TwitchApiClientSecretPasswordBox.Password = secretKeys.Twitch.Api.Secret;

        DeepLApiKeyPasswordBox.Password = secretKeys.DeepL.ApiKey;

        BouyomiChanConnectCheckBox.IsChecked = secretKeys.BouyomiChan.Checked;

        FollowEventCheckBox.IsChecked = secretKeys.Event.Follow.Checked;
        FollowEventTextBox.Text = secretKeys.Event.Follow.Message;

        RaidEventCheckBox.IsChecked = secretKeys.Event.Raid.Checked;
        RaidEventTextBox.Text = secretKeys.Event.Raid.Message;

        SubscriptionEventCheckBox.IsChecked = secretKeys.Event.Subscription.Checked;
        SubscriptionEventTextBox.Text = secretKeys.Event.Subscription.Message;

        BitsEventCheckBox.IsChecked = secretKeys.Event.Bits.Checked;
        BitsEventTextBox.Text = secretKeys.Event.Bits.Message;

        GiftEventCheckBox.IsChecked = secretKeys.Event.Gift.Checked;
        GiftEventTextBox.Text = secretKeys.Event.Gift.Message;

        ChannelPointEventCheckBox.IsChecked = secretKeys.Event.ChannelPoint.Checked;
        ChannelPointEventTextBox.Text = secretKeys.Event.ChannelPoint.Message;

        CycleTimer1CheckBox.IsChecked = secretKeys.CycleMessage.Timer1.Checked;
        CycleTimer1Slider.Value = secretKeys.CycleMessage.Timer1.Interval;
        CycleTimer1TextBox.Text = secretKeys.CycleMessage.Timer1.Message;

        CycleTimer2CheckBox.IsChecked = secretKeys.CycleMessage.Timer2.Checked;
        CycleTimer2Slider.Value = secretKeys.CycleMessage.Timer2.Interval;
        CycleTimer2TextBox.Text = secretKeys.CycleMessage.Timer2.Message;

        CycleTimer3CheckBox.IsChecked = secretKeys.CycleMessage.Timer3.Checked;
        CycleTimer3Slider.Value = secretKeys.CycleMessage.Timer3.Interval;
        CycleTimer3TextBox.Text = secretKeys.CycleMessage.Timer3.Message;

        CycleTimer4CheckBox.IsChecked = secretKeys.CycleMessage.Timer4.Checked;
        CycleTimer4Slider.Value = secretKeys.CycleMessage.Timer4.Interval;
        CycleTimer4TextBox.Text = secretKeys.CycleMessage.Timer4.Message;

        FixedTimer1CheckBox.IsChecked = secretKeys.FixedMessage.Timer1.Checked;
        FixedTimer1DatePicker.SelectedDate = DateTime.Parse(secretKeys.FixedMessage.Timer1.DatetimeString);
        FixedTimer1TimePicker.SelectedTime = DateTime.Parse(secretKeys.FixedMessage.Timer1.DatetimeString);
        FixedTimer1TextBox.Text = secretKeys.FixedMessage.Timer1.Message;

        FixedTimer2CheckBox.IsChecked = secretKeys.FixedMessage.Timer2.Checked;
        FixedTimer2DatePicker.SelectedDate = DateTime.Parse(secretKeys.FixedMessage.Timer2.DatetimeString);
        FixedTimer2TimePicker.SelectedTime = DateTime.Parse(secretKeys.FixedMessage.Timer2.DatetimeString);
        FixedTimer2TextBox.Text = secretKeys.FixedMessage.Timer2.Message;

        FixedTimer3CheckBox.IsChecked = secretKeys.FixedMessage.Timer3.Checked;
        FixedTimer3DatePicker.SelectedDate = DateTime.Parse(secretKeys.FixedMessage.Timer3.DatetimeString);
        FixedTimer3TimePicker.SelectedTime = DateTime.Parse(secretKeys.FixedMessage.Timer3.DatetimeString);
        FixedTimer3TextBox.Text = secretKeys.FixedMessage.Timer3.Message;

        FixedTimer4CheckBox.IsChecked = secretKeys.FixedMessage.Timer4.Checked;
        FixedTimer4DatePicker.SelectedDate = DateTime.Parse(secretKeys.FixedMessage.Timer4.DatetimeString);
        FixedTimer4TimePicker.SelectedTime = DateTime.Parse(secretKeys.FixedMessage.Timer4.DatetimeString);
        FixedTimer4TextBox.Text = secretKeys.FixedMessage.Timer4.Message;
    }

    /// <summary>
    /// </summary>
    private void InitializeChatWindow()
    {
        ShowChatWindow();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private async Task StartTimer()
    {
        var timer1Count = 0;
        var timer2Count = 0;
        var timer3Count = 0;
        var timer4Count = 0;
        while (true)
        {
            while (_twitchClientController is null) await Task.Delay(1);

            // Timerは秒数管理しても大丈夫
            await Task.Delay(1000);

            // Interval Timer
            if (CycleTimer1CheckBox.IsChecked ?? false) timer1Count++;
            else timer1Count = 0;
            if (CycleTimer2CheckBox.IsChecked ?? false) timer2Count++;
            else timer2Count = 0;
            if (CycleTimer3CheckBox.IsChecked ?? false) timer3Count++;
            else timer3Count = 0;
            if (CycleTimer4CheckBox.IsChecked ?? false) timer4Count++;
            else timer4Count = 0;

            var cycleTimer1Minute = (int) CycleTimer1Slider.Value * 60;
            if (timer1Count >= cycleTimer1Minute)
            {
                timer1Count %= cycleTimer1Minute;
                _twitchClientController.SendModeratorMessage(CycleTimer1TextBox.Text);
            }

            var cycleTimer2Minute = (int) CycleTimer2Slider.Value * 60;
            if (timer2Count >= cycleTimer2Minute)
            {
                timer2Count %= cycleTimer1Minute;
                _twitchClientController.SendModeratorMessage(CycleTimer1TextBox.Text);
            }

            var cycleTimer3Minute = (int) CycleTimer3Slider.Value * 60;
            if (timer3Count >= cycleTimer3Minute)
            {
                timer3Count %= cycleTimer3Minute;
                _twitchClientController.SendModeratorMessage(CycleTimer1TextBox.Text);
            }

            var cycleTimer4Minute = (int) CycleTimer3Slider.Value * 60;
            if (timer4Count >= cycleTimer4Minute)
            {
                timer4Count %= cycleTimer4Minute;
                _twitchClientController.SendModeratorMessage(CycleTimer1TextBox.Text);
            }

            // FixedTimer
            if (FixedTimer1CheckBox.IsChecked ?? false)
            {
                var date = FixedTimer1DatePicker.SelectedDate;
                var time = FixedTimer1TimePicker.SelectedTime;
                FixedTimerMessage(date, time, FixedTimer1TextBox.Text);
            }

            if (FixedTimer2CheckBox.IsChecked ?? false)
            {
                var date = FixedTimer2DatePicker.SelectedDate;
                var time = FixedTimer2TimePicker.SelectedTime;
                FixedTimerMessage(date, time, FixedTimer2TextBox.Text);
            }

            if (FixedTimer3CheckBox.IsChecked ?? false)
            {
                var date = FixedTimer3DatePicker.SelectedDate;
                var time = FixedTimer3TimePicker.SelectedTime;
                FixedTimerMessage(date, time, FixedTimer3TextBox.Text);
            }

            if (FixedTimer4CheckBox.IsChecked ?? false)
            {
                var date = FixedTimer4DatePicker.SelectedDate;
                var time = FixedTimer4TimePicker.SelectedTime;
                FixedTimerMessage(date, time, FixedTimer4TextBox.Text);
            }
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="date"></param>
    /// <param name="time"></param>
    /// <param name="message"></param>
    private void FixedTimerMessage(DateTime? date, DateTime? time, string message)
    {
        if (date is null || time is null) return;

        var datetime = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value.Hour,
            time.Value.Minute, time.Value.Second);
        if (DateTime.Now >= datetime && (DateTime.Now - datetime).TotalSeconds < 1)
            _twitchClientController?.SendModeratorMessage(message);
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private async Task StartWebServer()
    {
        var accessTokenQuery = new[] {$"http://localhost:{Settings.Default.Port}", "code=", "scope=", "state="};
        while (true)
        {
            await Task.Delay(1);
            if (FaraBotModeratorWebView.Source is null)
                continue;

            var url = FaraBotModeratorWebView.Source.ToString();
            // URL毎に処理を追加
            if (accessTokenQuery.All(key => url.Contains(key))) await Task.Run(() => UpdateAccessToken(url));
        }
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private async Task StartMonitoring()
    {
        InitializeDeepLChart();

        while (true)
        {
            await Task.Delay(1);
            // Token期限
            if (DateTime.Now > Settings.Default.expiresDateTime)
            {
                TwitchApiNotificationCanvas.Visibility = Visibility.Visible;
                if (!string.IsNullOrEmpty(Settings.Default.RefreshToken)) await Task.Run(UpdateRefreshToken);
            }
            else
            {
                TwitchApiNotificationCanvas.Visibility = Visibility.Hidden;
            }

            TwitchApiExpireDateTimeTextBlock.Text = $"Token expiration: {Settings.Default.expiresDateTime}";

            // Button無効
            TwitchApiAuthorizeButton.IsEnabled = !string.IsNullOrEmpty(TwitchApiClientIdPasswordBox.Password) &&
                                                 !string.IsNullOrEmpty(TwitchApiClientSecretPasswordBox.Password);

            if (_twitchClientController is not null) AddGridViewChatData();
        }
    }

    private async Task StartTwitchLibPubSub()
    {
        while (true)
        {
            while (_twitchClientController is null) await Task.Delay(1);

            await Task.Delay(1);
            TwitchConnectionStateLabel.Content = _twitchClientController.IsConnectTwitchPubSub() ? @"State: Connect" : @"State: Disconnect";
        }
    }
    
    private void InitializeDeepLChart()
    {
        /*
        LiveChartGraph.ChartAreas.Clear();
        LiveChartGraph.Series.Clear();
        var chartArea = new ChartArea();
        var chartAreaAxes = new Axis();
        chartAreaAxes.Interval = 1;
        chartAreaAxes.IntervalAutoMode = IntervalAutoMode.FixedCount;
        chartAreaAxes.IntervalOffset = 1;
        chartAreaAxes.IntervalType = DateTimeIntervalType.Months;
        chartAreaAxes.IntervalOffsetType = DateTimeIntervalType.Months;
        var series = new Series();
        series.ChartType = SeriesChartType.Spline;
        series.Name = "Characters";
        series.XValueType = ChartValueType.Date;
        // chartArea.Axes.(chartAreaAxes);
        LiveChartGraph.ChartAreas.Add(chartArea);
        LiveChartGraph.Series.Add(series);
        // LiveChartGraph.Series.Add();
        */
    }

    /// <summary>
    /// </summary>
    private void AddGridViewChatData()
    {
        if (_chatWindow is null) return;

        var chatModelData = _twitchClientController?.PickChatData();
        if (chatModelData is null) return;

        var beforeScrollBottom = true;

        var beforeScrollViewer =
            VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(_chatWindow.TwitchChatDataGrid, 0), 0);
        if (beforeScrollViewer is ScrollViewer viewer)
        {
            var offset = viewer.VerticalOffset;
            var extent = viewer.ScrollableHeight;
            var viewport = viewer.ViewportHeight;

            beforeScrollBottom = offset + viewport >= extent;
        }

        _chatWindow.TwitchChatDataGrid.Items.Add(chatModelData);
        if (beforeScrollBottom) _chatWindow.TwitchChatDataGrid.ScrollIntoView(chatModelData);
    }

    /// <summary>
    ///     Token期限切れの時に呼び出してTokenを更新します。
    /// </summary>
    /// <exception cref="HttpRequestException"></exception>
    private void UpdateRefreshToken()
    {
        var parameter =
            $"client_id={TwitchApiClientIdPasswordBox.Password}" +
            $"&client_secret={TwitchApiClientIdPasswordBox.Password}" +
            "&grant_type=refresh_token" +
            $"&refresh_token={Settings.Default.RefreshToken}";
        try
        {
            var response = Task.Run(() => PostResponseBodyAsync(parameter, "https://id.twitch.tv/oauth2/token")).Result;
            var jsonString =
                JsonSerializer.Deserialize<TwitchRefreshTokenModel>(response.responseBody, response.option);

            Settings.Default.AccessToken = jsonString?.AccessToken;
            Settings.Default.RefreshToken = jsonString?.RefreshToken;
            Settings.Default.Save();
        }
        catch (Exception ex)
        {
            LogController.OutputLog(ex.Message);
            RequestApiAccessToken();
        }
    }

    /// <summary>
    ///     Twitch API Access Tokenを取得、更新します。
    ///     Token取得はPOST通信をするため、WebViewは通さずPostRequestを行う。
    /// </summary>
    /// <param name="url"></param>
    /// <exception cref="HttpRequestException"></exception>
    private void UpdateAccessToken(string url)
    {
        var state = Regex.Match(url, @"state=(.*)").Groups[1];
        if (state.ToString() != Settings.Default.OAuth2State)
        {
            var message = "The token differs between request and response.";
            LogController.OutputLog(message);
            throw new HttpRequestException(message);
        }

        var code = Regex.Match(url, @"code=(.*)&").Groups[1];
        var parameter =
            $"client_id={TwitchApiClientIdPasswordBox.Password}" +
            $"&client_secret={TwitchApiClientSecretPasswordBox.Password}" +
            $"&code={code}" +
            "&grant_type=authorization_code" +
            $"&redirect_uri=http://localhost:{Settings.Default.Port}";
        var response = Task.Run(() => PostResponseBodyAsync(parameter, "https://id.twitch.tv/oauth2/token")).Result;

        // Token取得失敗は何もしない
        if (response.responseBody.Contains("Invalid authorization code")) return;

        var jsonString =
            JsonSerializer.Deserialize<TwitchOAuthTokenModel>(response.responseBody, response.option);
        Settings.Default.AccessToken = jsonString?.AccessToken;
        Settings.Default.RefreshToken = jsonString?.RefreshToken;
        if (jsonString?.ExpiresIn != null)
            Settings.Default.expiresDateTime = DateTime.Now.AddSeconds(jsonString.ExpiresIn);
        Settings.Default.Save();

        UnlockWindowControl();
    }

    /// <summary>
    ///     accessTokenに必要な認証コードを取得するURLを開く
    /// </summary>
    private void RequestApiAccessToken()
    {
        var buffer = RandomNumberGenerator.GetBytes(50);
        var stateGenerator =
            buffer.Select(x => x % 62)
                .Select(x =>
                {
                    // 特殊文字は含めない
                    return x switch
                    {
                        < 10 => (char) ('0' + x),
                        < 36 => (char) ('A' + x - 10),
                        _ => (char) ('a' + x - 36)
                    };
                }).ToArray();
        var state = new string(stateGenerator);
        Settings.Default.OAuth2State = state;
        Settings.Default.Save();

        //refreshTokenはaccessToken期限切れなら設定
        var requestUrl =
            "https://id.twitch.tv/oauth2/authorize" +
            $"?client_id={TwitchApiClientIdPasswordBox.Password}" +
            $"&redirect_uri=http://localhost%3A{Settings.Default.Port}" +
            "&response_type=code" +
            "&scope=bits%3Aread " + // bitsリーダーボード表示
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
            "moderation%3Aread " + // Moderators, Bans, Timeouts, Automod設定
            "moderator%3Amanage%3Aannouncements " + // Moderator権限者によるannouncementコマンド実行
            "user%3Aread%3Abroadcast " + // broadcast設定取得
            "user%3Aread%3Afollows " + // follower取得
            "user%3Aread%3Asubscriptions " + // SubScriptionメンバー一覧取得
            "user%3Aread%3Aemail " + // mail取得
            "channel%3Amoderate " + // Moderator権限実行
            "chat%3Aedit " + // Chat送信
            "chat%3Aread " + // Chat受信
            "whispers:read" + // Whisper受信
            $"&state={state}"; // ランダムなUID
        try
        {
            LockWindowControl();
            FaraBotModeratorWebView.Source = new Uri(requestUrl); // WebView表示して操作
        }
        catch (Exception ex)
        {
            UnlockWindowControl();
            LogController.OutputLog(ex.Message);
        }
    }

    /// <summary>
    ///     指定URLに対してPost Requestを送信します。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    private async Task<(string responseBody, JsonSerializerOptions option)> PostResponseBodyAsync(string parameter,
        string url)
    {
        using var httpClient = new HttpClient();
        var content = new StringContent(parameter, Encoding.Default, "application/x-www-form-urlencoded");
        var response = await httpClient.PostAsync(url, content);

        var responseBody = response.Content.ReadAsStringAsync().Result;
        var option = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        return (responseBody, option);
    }

    /// <summary>
    ///     Control全体をロック
    /// </summary>
    private void LockWindowControl()
    {
        Dispatcher.Invoke((Action) (() =>
        {
            TwitchClientAccessTokenButton.IsEnabled = false;
            TwitchApiAuthorizeButton.IsEnabled = false;
            TwitchConnectionButton.IsEnabled = false;
            TwitchDisconnectButton.IsEnabled = false;
            TwitchPageButton.IsEnabled = false;
            DeepLSiteGoButton.IsEnabled = false;
        }));
    }

    /// <summary>
    ///     Control全体のロックを解除
    /// </summary>
    private void UnlockWindowControl()
    {
        Dispatcher.Invoke((Action) (() =>
        {
            TwitchClientAccessTokenButton.IsEnabled = true;
            TwitchApiAuthorizeButton.IsEnabled = true;
            TwitchConnectionButton.IsEnabled = true;
            TwitchDisconnectButton.IsEnabled = true;
            TwitchPageButton.IsEnabled = true;
            DeepLSiteGoButton.IsEnabled = true;
        }));
    }

    /// <summary>
    ///     Chat窓表示
    /// </summary>
    private void ShowChatWindow()
    {
        _chatWindow ??= new ChatWindow();
        _chatWindow.Show();
        _chatWindow.OnTwitchRequestChatButtonClick += ChatWindow_OnTwitchRequestChatButtonClick;
    }

    /// <summary>
    ///     Secretの値を保存します。
    /// </summary>
    private void SaveSecretValue()
    {
        var timer1 =
            (FixedTimer1DatePicker.SelectedDate is not null
                ? FixedTimer1DatePicker.SelectedDate.Value.ToShortDateString()
                : "2023/1/1") + " " +
            (FixedTimer1TimePicker.SelectedTime is not null
                ? FixedTimer1TimePicker.SelectedTime.Value.ToLongTimeString()
                : "00:00:00");
        var timer2 =
            (FixedTimer2DatePicker.SelectedDate is not null
                ? FixedTimer2DatePicker.SelectedDate.Value.ToShortDateString()
                : "2023/1/1") + " " +
            (FixedTimer2TimePicker.SelectedTime is not null
                ? FixedTimer2TimePicker.SelectedTime.Value.ToLongTimeString()
                : "00:00:00");
        var timer3 =
            (FixedTimer3DatePicker.SelectedDate is not null
                ? FixedTimer3DatePicker.SelectedDate.Value.ToShortDateString()
                : "2023/1/1") + " " +
            (FixedTimer3TimePicker.SelectedTime is not null
                ? FixedTimer3TimePicker.SelectedTime.Value.ToLongTimeString()
                : "00:00:00");
        var timer4 =
            (FixedTimer4DatePicker.SelectedDate is not null
                ? FixedTimer4DatePicker.SelectedDate.Value.ToShortDateString()
                : "2023/1/1") + " " +
            (FixedTimer4TimePicker.SelectedTime is not null
                ? FixedTimer4TimePicker.SelectedTime.Value.ToLongTimeString()
                : "00:00:00");

        var secretKeys = new SecretKeyModel
        {
            Twitch = new TwitchSecretKeyModel
            {
                Client = new TwitchClientKeyModel
                {
                    UserName = TwitchClientUserNameTextBox.Text, // TwitchのURLの末尾の名前
                    AccessToken = TwitchClientAccessTokenPasswordBox.Password,
                    DisplayName = TwitchClientDisplayNameTextBox.Text
                },
                Api = new TwitchApiKeyModel
                {
                    ClientId = TwitchApiClientIdPasswordBox.Password,
                    Secret = TwitchApiClientSecretPasswordBox.Password
                }
            },
            DeepL = new DeepLKeyModel
            {
                ApiKey = DeepLApiKeyPasswordBox.Password
            },
            BouyomiChan = new BouyomiChanModel
            {
                Checked = BouyomiChanConnectCheckBox.IsChecked ?? false
            },
            Event = new ReactionEventModel
            {
                Follow = new ReactionFollowEvent
                {
                    Checked = FollowEventCheckBox.IsChecked ?? false,
                    Message = FollowEventTextBox.Text
                },
                Raid = new ReactionRaidEvent
                {
                    Checked = RaidEventCheckBox.IsChecked ?? false,
                    Message = RaidEventTextBox.Text
                },
                Subscription = new ReactionSubscriptionEvent
                {
                    Checked = SubscriptionEventCheckBox.IsChecked ?? false,
                    Message = SubscriptionEventTextBox.Text
                },
                Bits = new ReactionBitsEvent
                {
                    Checked = BitsEventCheckBox.IsChecked ?? false,
                    Message = BitsEventTextBox.Text
                },
                Gift = new ReactionGiftEvent
                {
                    Checked = GiftEventCheckBox.IsChecked ?? false,
                    Message = GiftEventTextBox.Text
                },
                ChannelPoint = new ReactionChannelPointEvent
                {
                    Checked = ChannelPointEventCheckBox.IsChecked ?? false,
                    Message = ChannelPointEventTextBox.Text
                }
            },
            CycleMessage = new CycleMessageModel
            {
                Timer1 = new CycleTimerModel
                {
                    Checked = CycleTimer1CheckBox.IsChecked ?? false,
                    Interval = (int) CycleTimer1Slider.Value,
                    Message = CycleTimer1TextBox.Text
                },
                Timer2 = new CycleTimerModel
                {
                    Checked = CycleTimer2CheckBox.IsChecked ?? false,
                    Interval = (int) CycleTimer2Slider.Value,
                    Message = CycleTimer2TextBox.Text
                },
                Timer3 = new CycleTimerModel
                {
                    Checked = CycleTimer3CheckBox.IsChecked ?? false,
                    Interval = (int) CycleTimer3Slider.Value,
                    Message = CycleTimer3TextBox.Text
                },
                Timer4 = new CycleTimerModel
                {
                    Checked = CycleTimer4CheckBox.IsChecked ?? false,
                    Interval = (int) CycleTimer4Slider.Value,
                    Message = CycleTimer4TextBox.Text
                }
            },
            FixedMessage = new FixedMessageModel
            {
                Timer1 = new FixedTimerModel
                {
                    Checked = FixedTimer1CheckBox.IsChecked ?? false,
                    DatetimeString = timer1,
                    Message = FixedTimer1TextBox.Text
                },
                Timer2 = new FixedTimerModel
                {
                    Checked = FixedTimer2CheckBox.IsChecked ?? false,
                    DatetimeString = timer2,
                    Message = FixedTimer2TextBox.Text
                },
                Timer3 = new FixedTimerModel
                {
                    Checked = FixedTimer3CheckBox.IsChecked ?? false,
                    DatetimeString = timer3,
                    Message = FixedTimer3TextBox.Text
                },
                Timer4 = new FixedTimerModel
                {
                    Checked = FixedTimer4CheckBox.IsChecked ?? false,
                    DatetimeString = timer4,
                    Message = FixedTimer4TextBox.Text
                }
            }
        };

        SecretKeyController.SaveKeys(secretKeys);
    }

    /// <summary>
    /// </summary>
    private void TwitchConnect()
    {
        var secretKeys = SecretKeyController.LoadKeys();

        _twitchApiController = new TwitchApiController(secretKeys);
        var channelId = _twitchApiController.GetTwitchChannelId(secretKeys.Twitch.Client.UserName);

        _twitchClientController = new TwitchClientController(secretKeys, _twitchApiController);
        _twitchClientController.Connect();

        _twitchPubSubController = new TwitchPubSubController(_twitchClientController, channelId);
        _twitchPubSubController.Connect();
    }

    /// <summary>
    /// </summary>
    private void TwitchDisconnect()
    {
        _twitchPubSubController?.Disconnect();
        _twitchClientController?.Disconnect();

        _twitchClientController = null;
        _twitchApiController = null;
        _twitchPubSubController = null;
    }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    private void ChatWindow_OnTwitchRequestChatButtonClick(string message)
    {
        _twitchClientController?.MessageTranslationProcess(message, TwitchClientUserNameTextBox.Text,
            TwitchClientDisplayNameTextBox.Text);
        if (_chatWindow != null) _chatWindow.TwitchRequestChatTextBox.Text = "";
    }

    /// <summary>
    ///     UserNameで設定したユーザのTwitchページ表示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchPageButton_Click(object sender, RoutedEventArgs e)
    {
        FaraBotModeratorWebView.Source = new Uri($"https://twitch.tv/{TwitchClientUserNameTextBox.Text}");
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchConnectionButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            SaveSecretValue();

            var state = TwitchConnectionStateLabel.Content.ToString();
            if (state is not null && state.Equals("State: Connect")) TwitchDisconnect();
            TwitchConnect();
        }
        catch (Exception ex)
        {
            LogController.OutputLog(ex.Message);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchDisconnectButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            TwitchDisconnect();
        }
        catch (Exception ex)
        {
            LogController.OutputLog(ex.Message);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchClientAccessTokenButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            FaraBotModeratorWebView.Source = new Uri("https://twitchapps.com/tmi/");
        }
        catch (Exception ex)
        {
            LogController.OutputLog(ex.Message);
        }
    }

    /// <summary>
    ///     Twitch API Token取得前のTwitch Loginページを表示します。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchApiAuthorizeButton_Click(object sender, RoutedEventArgs e)
    {
        RequestApiAccessToken();
    }

    /// <summary>
    ///     DeepLサイトを表示します。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeepLSiteGoButton_Click(object sender, RoutedEventArgs e)
    {
        MenuTabControl.SelectedIndex = 0;
        FaraBotModeratorWebView.Source = new Uri("https://www.deepl.com/ja/account/summary");
    }

    /// <summary>
    ///     LiveChartのUpdateボタン押したときの処理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LiveChartUpdateButton_Click(object sender, RoutedEventArgs e)
    {
    }

    /// <summary>
    ///     終了時の処理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MainWindow_Closed(object sender, EventArgs e)
    {
        SaveSecretValue();
    }

    /// <summary>
    ///     WebViewが読み込まれた後の処理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FaraBotModeratorWebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        FaraBotModeratorWebView.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = false; //ダイアログ表示を抑止
        FaraBotModeratorWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false; //コンテキストメニューを抑止
        FaraBotModeratorWebView.CoreWebView2.Settings.AreDevToolsEnabled = false; //開発者ツールを無効化
        FaraBotModeratorWebView.CoreWebView2.Settings.IsBuiltInErrorPageEnabled = false; //ブラウザに組み込まれているエラーページを無効化
        FaraBotModeratorWebView.CoreWebView2.Settings.IsZoomControlEnabled = false; //ズームコントロールを無効化
        FaraBotModeratorWebView.CoreWebView2.Settings.IsStatusBarEnabled = false; //ステータスバーを非表示
    }

    private void CycleTimerSlider_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
    {
        ((Slider) sender).ToolTip = ((Slider) sender).Value.ToString(CultureInfo.CurrentCulture);
    }

    private void CycleTimerSlider_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
    {
        ((Slider) sender).ToolTip = ((Slider) sender).Value.ToString(CultureInfo.CurrentCulture);
    }
}