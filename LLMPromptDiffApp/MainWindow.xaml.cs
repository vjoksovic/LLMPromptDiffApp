using System.Windows;
using System.Windows.Controls;

namespace LLMPromptDiffApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CodeEditorTab_Click(object sender, RoutedEventArgs e)
    {
        // Switch to Code Editor tab
        CodeEditorTab.Style = (Style)FindResource("ActiveTabButtonStyle");
        PromptPreviewTab.Style = (Style)FindResource("TabButtonStyle");
        
        CodeEditorView.Visibility = Visibility.Visible;
        PromptPreviewView.Visibility = Visibility.Collapsed;
    }

    private void PromptPreviewTab_Click(object sender, RoutedEventArgs e)
    {
        // Switch to Prompt Preview tab
        PromptPreviewTab.Style = (Style)FindResource("ActiveTabButtonStyle");
        CodeEditorTab.Style = (Style)FindResource("TabButtonStyle");
        
        PromptPreviewView.Visibility = Visibility.Visible;
        CodeEditorView.Visibility = Visibility.Collapsed;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    public void SwitchToPromptPreview()
    {
        PromptPreviewTab_Click(this, new RoutedEventArgs());
    }
}