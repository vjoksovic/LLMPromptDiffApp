# LLM Prompt Diff App

## Features

- **Code Comparison**: Compare original and modified code with visual diff highlighting
- **Visual Diff Display**: Color-coded diff visualization (red for deletions, green for additions)
- **AI Prompt Generation**: Automatically generate structured prompts for LLM code review
- **Real-time Updates**: Live diff calculation as you edit code

## Technology Stack

- **Framework**: .NET 9.0 with WPF
- **Diff Engine**: DiffPlex library for code comparison
- **UI**: XAML with custom dark theme styling
- **Architecture**: MVVM pattern with data binding

## Project Structure

```
LLMPromptDiffApp/
├── Models/
│   └── ModifiedCode.cs
├── Services/
│   ├── DiffService.cs           # Handles diff calculation and
│   └── PromptService.cs         # Generates AI prompts from diffs
├── Views/
│   ├── CodeEditorView.xaml      # Main code editing interface
│   ├── CodeEditorView.xaml.cs
│   ├── PromptPreviewView.xaml   # Prompt display interface
│   └── PromptPreviewView.xaml.cs
├── Utils/
│   └── FileUtils.cs             # File I/O utilities
├── Examples/
│   ├── DataService.cs
│   └── PrintService.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
└── App.xaml
```

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or JetBrains Rider (recommended)

### Installation

1. Clone the repository:

   ```bash
   git clone <repository-url>
   cd LLMPromptDiffApp
   ```

2. Restore NuGet packages:

   ```bash
   dotnet restore
   ```

3. Build the application:

   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

## Usage

### Loading Code Files

1. Open the application
2. In the Code Editor tab, use the dropdown to select from example files in the `Examples/` directory
3. The selected file content will load into the "Original Code" text area

### Comparing Code Changes

1. Edit the code in the "Current Code" text area to make your modifications
2. Click the "Compare" button to generate a visual diff
3. View the color-coded differences in the diff display area:
   - **Red text**: Deleted lines
   - **Green text**: Added lines
   - **White text**: Unchanged lines

### Generating AI Prompts

1. After comparing your code changes, click "Create Prompt"
2. The application will automatically switch to the Prompt Preview tab
3. View the generated prompt that can be used with LLM services for code review

### Example Workflow

1. Load `DataService.cs` from the examples
2. Modify the code (e.g., add error handling, change method signatures)
3. Click "Compare" to see the differences
4. Click "Create Prompt" to generate an AI review prompt
5. Copy the prompt to use with ChatGPT, Claude, or other LLM services

## Dependencies

- **DiffPlex 1.9.0**: For performing text diffs and generating diff models
- **.NET 9.0**: Runtime and framework
- **WPF**: Windows Presentation Foundation for the UI

## Configuration

The application looks for example files in the `Examples/` directory relative to the executable. You can add your own `.cs` files to this directory to test with different code samples.

## Development

The application follows a clean architecture pattern:

- **Models**: Data structures and business logic
- **Services**: Core functionality
- **Views**: UI components and user interactions
- **Utils**: Helper functions and utilities

## Future Enhancements

Potential improvements for future versions:

- Support for multiple file types (not just C#)
- Integration with popular LLM APIs
- Syntax highlighting in code editors
- Custom prompt templates
- Batch processing of multiple files
