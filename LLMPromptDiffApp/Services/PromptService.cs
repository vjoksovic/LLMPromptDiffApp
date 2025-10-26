namespace LLMPromptDiffApp.Services;

public class PromptService
{
    public static string MakePrompt(string diff)
    {
        return
            "You are an expert code analysis assistant helping to classify and understand code modifications.\n" +
            "Your goal is to analyze the provided diff, identify what kind of change it represents, and explain why it may be desirable or undesirable.\n" +
            "\n" +
            "Here is the modified code (each changed line is marked as inserted or deleted):\n" +
            "\n" +
            diff +
            "\n\n" +
            "Follow these steps in your analysis:\n" +
            "1. Classify the change into one of the following categories:\n" +
            "   - Readability improvement\n" +
            "   - Readability degradation\n" +
            "   - Maintainability improvement\n" +
            "   - Maintainability degradation\n" +
            "   - Performance optimization\n" +
            "   - Performance risk\n" +
            "   - Neutral / stylistic change\n" +
            "2. Describe which language features are used and whether they interact in a way that might reduce clarity or cause confusion.\n" +
            "3. Identify patterns or repeated structures in the modified code that could suggest consolidation or abstraction.\n" +
            "4. Explain *why* the change might be undesirable, focusing on readability, complexity, or debugging difficulty.\n" +
            "5. Provide a short, structured reasoning summary.\n" +
            "\n" +
            "Format your response as:\n" +
            "- **Classification:** [one of the categories above]\n" +
            "- **Reasoning:** Explanation of why this classification was chosen.\n" +
            "- **Patterns Detected:** Any notable structural or stylistic patterns.\n" +
            "- **Why Undesirable (if applicable):** Clear explanation of the negative impact.\n" +
            "- **Suggested Action:** Optional improvement or simplification idea.\n";
    }
}
