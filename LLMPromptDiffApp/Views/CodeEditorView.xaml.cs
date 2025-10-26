using System.Windows;
using System.Windows.Controls;
using LLMPromptDiffApp.Services;
using LLMPromptDiffApp.Models;
using LLMPromptDiffApp.Utils;


namespace LLMPromptDiffApp.Views;

public partial class CodeEditorView : UserControl
{
    private readonly DiffService _diffService;
    private ModifiedCode _code;

    public CodeEditorView()
    {
        InitializeComponent();
        _diffService = new DiffService();
        LoadExampleFiles();
        _code = new ModifiedCode();
        DataContext = _code;
    }

    private void LoadExampleFiles()
    {
        LoadFileComboBox.Items.Clear();
        var files = FileUtils.GetFilesFromDirectory();
        
        foreach (var file in files)
        {
            var item = new ComboBoxItem()
            { 
                Content = file,
                Style = (Style)FindResource("DarkComboBoxItemStyle")
            };
            item.Tag = file;
            item.MouseLeftButtonUp += (sender, e) => LoadFileContent(file);
            LoadFileComboBox.Items.Add(item);
        }
    }

    private void LoadFileContent(string fileName)
    {
        var content = FileUtils.ReadFileContent(fileName);
        
        if (content != null)
        {
            _code = new ModifiedCode(content);
            DataContext = _code;
        }
    }

    private void LoadFileComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (LoadFileComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag is string fileName)
        {
            LoadFileContent(fileName);
        }
    }

    private void CompareButton_Click(object sender, RoutedEventArgs e)
    {
        _code.CodeDiff = _diffService.BuildFormattedDiff(_code);
        DisplayColoredDiff();
    }

    private void DisplayColoredDiff()
    {
        DiffRichTextBox.Document.Blocks.Clear();
        var paragraph = _diffService.BuildColoredDiff();
        DiffRichTextBox.Document.Blocks.Add(paragraph);
    }

    private void CreatePromptButton_Click(object sender, RoutedEventArgs e)
    {
        var codeDifference = _code.CodeDiff;
        var prompt = PromptService.MakePrompt(codeDifference);
        ShowPromptInPreview(prompt);
    }

    private static void ShowPromptInPreview(string prompt)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        if (mainWindow != null)
        {
            // Switch to the Prompt Preview tab
            mainWindow.SwitchToPromptPreview();
            
            var promptPreviewView = mainWindow.FindName("PromptPreviewView") as PromptPreviewView;
            if (promptPreviewView != null)
            {
                promptPreviewView.SetPrompt(prompt);
            }
        }
    }
}