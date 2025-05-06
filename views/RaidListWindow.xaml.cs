using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using FaraBotModerator.controllers;
using FaraBotModerator.models;
using Button = System.Windows.Controls.Button;
using Clipboard = System.Windows.Forms.Clipboard;

namespace FaraBotModerator.views;

/// <summary>
/// 
/// </summary>
public partial class RaidListWindow : Window
{
    private readonly TwitchApiController _twitchApiController;

    /// <summary>
    /// 
    /// </summary>
    public RaidListWindow(TwitchApiController twitchApiController)
    {
        _twitchApiController = twitchApiController;
        InitializeComponent();
    }

    private void SetRaidDataGridView(List<StreamingUserModel> streamingUsers)
    {
        var beforeScrollBottom = true;
        var beforeScrollViewer =
            VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(TwitchRaidDataGrid, 0), 0);
        if (beforeScrollViewer is ScrollViewer viewer)
        {
            var offset = viewer.VerticalOffset;
            var extent = viewer.ScrollableHeight;
            var viewport = viewer.ViewportHeight;

            beforeScrollBottom = offset + viewport >= extent;
        }

        foreach (var streamingUser in streamingUsers)
        {
            TwitchRaidDataGrid.Items.Add(streamingUser);
            if (beforeScrollBottom) TwitchRaidDataGrid.ScrollIntoView(streamingUser);
        }
    }

    private void DataGridRowRaidButton_OnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button) sender;
        var rowData = button.DataContext;

        if (rowData is StreamingUserModel userModel)
        {
            var command = $"/raid {userModel.LoginId}";
            Clipboard.SetText(command);

            // ボタンの親要素からPopupを探す
            var parent = VisualTreeHelper.GetParent(button);
            Popup popup = null;

            while (parent != null && popup == null)
            {
                if (parent is Grid grid)
                {
                    // Grid内の子要素を探索
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(grid); i++)
                    {
                        var child = VisualTreeHelper.GetChild(grid, i);
                        if (child is Popup foundPopup)
                        {
                            popup = foundPopup;
                            break;
                        }
                    }
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            if (popup != null)
            {
                // Popupを表示
                popup.IsOpen = true;

                // 2秒後に自動で閉じる
                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += (s, args) =>
                {
                    popup.IsOpen = false;
                    timer.Stop();
                };
                timer.Start();
            }
        }
    }

    private void TwitchStreamingFollowerButton_OnClick(object sender, RoutedEventArgs e)
    {
        TwitchRaidDataGrid.Items.Clear();
        var streamingUsers = _twitchApiController.GetStreamingFollowerUsers();
        SetRaidDataGridView(streamingUsers);
    }

    private void TwitchStreamingSameGameButton_OnClick(object sender, RoutedEventArgs e)
    {
        TwitchRaidDataGrid.Items.Clear();
        var streamingUsers = _twitchApiController.GetStreamingSameGameUsers();
        SetRaidDataGridView(streamingUsers);
    }
}