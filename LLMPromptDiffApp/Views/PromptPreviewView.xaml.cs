using System.Windows.Controls;
using LLMPromptDiffApp.Models;

namespace LLMPromptDiffApp.Views;

public partial class PromptPreviewView : UserControl
{
    public PromptPreviewView()
    {
        InitializeComponent();
    }

    public void SetPrompt(string prompt)
    {
        GeneratedPromptTextBox.Text = prompt;
    }
}