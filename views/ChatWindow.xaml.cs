using System.Windows;
using System.Windows.Input;
using FaraBotModerator.controllers;

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

    private readonly TwitchClientController _twitchClientController;

    /// <summary>
    /// </summary>
    public ChatWindow(TwitchClientController twitchClientController)
    {
        _twitchClientController = twitchClientController;
        InitializeComponent();
    }
    
    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchRequestChatTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        var message = TwitchRequestChatTextBox.Text;
        if (e.Key == Key.Enter)
        {
            _twitchClientController.SendApplicationMessage(message);
            TwitchRequestChatTextBox.Text = "";
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TwitchRequestChatButton_Click(object sender, RoutedEventArgs e)
    {
        var message = TwitchRequestChatTextBox.Text;
        _twitchClientController.SendApplicationMessage(message);
        TwitchRequestChatTextBox.Text = "";
    }
}