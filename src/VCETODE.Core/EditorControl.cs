
---

## File: src/VCETODE.Core/EditorControl.cs

```csharp
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Text.RegularExpressions;
using VCETODE.Core;

namespace VCETODE.Core
{
    /// <summary>
    /// A custom text editor control with built-in syntax highlighting.
    /// Currently supports basic Python keyword highlighting.
    /// </summary>
    public sealed class EditorControl : RichEditBox
    {
        public bool EnableIntellisense { get; set; } = true;
        // List of Python keywords to highlight (extend for other languages as needed)
        private static readonly string[] PythonKeywords = new string[]
        {
            "def", "class", "if", "else", "elif", "return", "import", "from", "as",
            "while", "for", "in", "try", "except", "with", "pass", "break", "continue",
            "True", "False", "None"
        };

        public EditorControl()
        {
            this.DefaultStyleKey = typeof(EditorControl);
            this.Document.SetText(TextSetOptions.None, "");
            this.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            this.TextChanged += EditorControl_TextChanged;
        }

        private void EditorControl_TextChanged(object sender, RoutedEventArgs e)
        {
            // Call syntax highlighting asynchronously to keep UI responsive.
            ApplySyntaxHighlighting();
        }

        /// <summary>
        /// Applies syntax highlighting by scanning for keywords and setting their color.
        /// </summary>
        public async void ApplySyntaxHighlighting()
        {
            try
            {
                string text;
                this.Document.GetText(TextGetOptions.None, out text);

                // Reset formatting for the entire document.
                var document = this.Document;
                var fullRange = document.GetRange(0, text.Length);
                fullRange.CharacterFormat.ForegroundColor = Windows.UI.Colors.White;

                // Loop through each keyword and apply formatting where found.
                foreach (var keyword in PythonKeywords)
                {
                    string pattern = $@"\b{Regex.Escape(keyword)}\b";
                    foreach (Match match in Regex.Matches(text, pattern))
                    {
                        var range = document.GetRange(match.Index, match.Index + match.Length);
                        range.CharacterFormat.ForegroundColor = Windows.UI.Colors.Cyan;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error applying syntax highlighting", ex);
            }
        }
    }
}
