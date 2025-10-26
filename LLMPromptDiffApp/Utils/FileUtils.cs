using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace LLMPromptDiffApp.Utils;

public static class FileUtils
{
    private const string DirectoryPath = "./Examples";
    public static List<string> GetFilesFromDirectory(string fileExtension = "*.cs")
    {
        try
        {
            return Directory.GetFiles(DirectoryPath , fileExtension)
                .Select(Path.GetFileName)
                .Where(fileName => !string.IsNullOrEmpty(fileName))
                .Cast<string>()
                .OrderBy(f => f)
                .ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error reading directory '{DirectoryPath}': {ex.Message}", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return new List<string>();
        }
    }
    
    public static string? ReadFileContent(string fileName)
    {
        try
        {
            var filePath = Path.Combine(DirectoryPath, fileName);
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error reading file '{fileName}': {ex.Message}", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
    }
    
}
