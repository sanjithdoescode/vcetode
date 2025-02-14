using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using VCETODE.Core;
using System;

namespace VCETODE.Terminal
{
    /// <summary>
    /// A custom terminal control that accepts user commands and displays output.
    /// </summary>
    public sealed class CustomTerminalControl : Control
    {
        private TextBox inputBox;
        private RichTextBlock outputBlock;

        public CustomTerminalControl()
        {
            this.DefaultStyleKey = typeof(CustomTerminalControl);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            inputBox = GetTemplateChild("PART_InputBox") as TextBox;
            outputBlock = GetTemplateChild("PART_OutputBlock") as RichTextBlock;
            if (inputBox != null)
            {
                inputBox.KeyDown += InputBox_KeyDown;
            }
        }

        private void InputBox_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                ExecuteCommand(inputBox.Text);
                inputBox.Text = "";
            }
        }

        private void ExecuteCommand(string command)
        {
            try
            {
                AppendOutput($"> {command}");
                // Extend: Add command parsing and execution logic here.
            }
            catch (Exception ex)
            {
                Logger.LogError("Error executing terminal command", ex);
                AppendOutput($"Error: {ex.Message}");
            }
        }

        private void AppendOutput(string text)
        {
            if (outputBlock != null)
            {
                var para = new Paragraph();
                para.Inlines.Add(new Run { Text = text });
                outputBlock.Blocks.Add(para);
            }
        }
    }
}
