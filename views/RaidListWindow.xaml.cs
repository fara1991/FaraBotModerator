using System.Windows;
using Clipboard = System.Windows.Forms.Clipboard;

namespace FaraBotModerator.views;

/// <summary>
/// 
/// </summary>
public partial class RaidListWindow : Window
{
    /// <summary>
    /// 
    /// </summary>
    public RaidListWindow()
    {
        InitializeComponent();
        // 特定のタイミングでraidコマンドをコピーしたい
        Clipboard.SetDataObject("test", true);
    }
}