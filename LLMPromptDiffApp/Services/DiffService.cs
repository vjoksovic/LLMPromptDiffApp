using System.Windows.Documents;
using System.Windows.Media;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using LLMPromptDiffApp.Models;

namespace LLMPromptDiffApp.Services;

public class DiffService
{
    private readonly InlineDiffBuilder _diffBuilder;
    private DiffPaneModel _model;

    public DiffService()
    {
        _diffBuilder = new InlineDiffBuilder(new Differ());
        _model = new DiffPaneModel();
    }
    
    public string BuildFormattedDiff(ModifiedCode code)
    {
        _model = _diffBuilder.BuildDiffModel(code.CurrentCode, code.OriginalCode);
        var result = "";
        
        foreach (var line in _model.Lines)
        {
            switch (line.Type)
            {
                case ChangeType.Unchanged:
                    result += $"unchanged: {line.Text}\n";
                    break;
                case ChangeType.Deleted:
                    result += $"deleted: {line.Text}\n";
                    break;
                case ChangeType.Inserted:
                    result += $"inserted: {line.Text}\n";
                    break;
                case ChangeType.Modified:
                    result += $"modified: {line.Text}\n";
                    break;
                default:
                    result += $"{line.Text}\n";
                    break;
            }
        }

        return result;
    }

    public Paragraph BuildColoredDiff()
    {
        var paragraph = new Paragraph();
        
        foreach (var line in _model.Lines)
        {
            var run = new Run()
            {
                FontFamily = new FontFamily("Consolas"),
                FontSize = 12
            };
            
            switch (line.Type)
            {
                case ChangeType.Deleted:
                    run.Text = $"deleted: {line.Text}\n";
                    run.Foreground = Brushes.Red;
                    break;
                case ChangeType.Inserted:
                    run.Text = $"inserted: {line.Text}\n";
                    run.Foreground = Brushes.Green;
                    break;
                default:
                    run.Text = $"  {line.Text}\n";
                    run.Foreground = Brushes.White;
                    break;
            }
            
            paragraph.Inlines.Add(run);
        }
        
        return paragraph;
    }
    
}