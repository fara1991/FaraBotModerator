using System.Windows;
using System.Windows.Input;

namespace FaraBotModerator.views;

/// <summary>
///     ChatWindow.xaml の相互作用ロジック
/// </summary>
public partial class ChatWindow : Window
{
    /// <summary>
    /// </summary>
    /// <param name="text"></param>
    public delegate void ButtonClickHandler(string text);

    private readonly MainWindow _mainWindow;

    /// <summary>
    /// </summary>
    /// <param name="mainWindow"></param>
    public ChatWindow(MainWindow mainWindow)
    {
        InitializeComponent();
        _mainWindow = mainWindow;
        // raid先一覧を取得できるといい https://dev.twitch.tv/docs/api/reference/#search-categories
        // follow一覧でもいい https://dev.twitch.tv/docs/api/reference/#get-followed-streams
        // 選択したらraidコマンド実行できるといい https://dev.twitch.tv/docs/api/reference/#start-a-raid
    }

    /// <summary>
    /// </summary>
    public event ButtonClickHandler? OnTwitchRequestChatButtonClick;

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchRequestChatTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) _mainWindow.ChatWindowSendMessage(TwitchRequestChatTextBox.Text);
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchRequestChatButton_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.ChatWindowSendMessage(TwitchRequestChatTextBox.Text);
    }
}