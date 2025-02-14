using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using VCETODE.Core;
using VCETODE.CompetitiveProgramming;

namespace VCETODE.UI
{
    public enum EditorMode
    {
        Learn,
        QuickShip,
        CompetitiveProgramming
    }

    public sealed partial class MainWindow : Window
    {
        public EditorMode CurrentMode { get; private set; } = EditorMode.QuickShip;
        private CPModeManager _cpModeManager;

        public MainWindow()
        {
            this.InitializeComponent();
            _cpModeManager = new CPModeManager();
            SetMode(CurrentMode);
        }

        private void LearnMode_Click(object sender, RoutedEventArgs e)
        {
            SetMode(EditorMode.Learn);
        }

        private void QuickShipMode_Click(object sender, RoutedEventArgs e)
        {
            SetMode(EditorMode.QuickShip);
        }

        private void CPMode_Click(object sender, RoutedEventArgs e)
        {
            SetMode(EditorMode.CompetitiveProgramming);
        }

        private void SetMode(EditorMode mode)
        {
            CurrentMode = mode;
            switch (mode)
            {
                case EditorMode.Learn:
                    EditorControl.EnableIntellisense = false;
                    CPPanel.Visibility = Visibility.Collapsed;
                    break;
                case EditorMode.QuickShip:
                    EditorControl.EnableIntellisense = true;
                    CPPanel.Visibility = Visibility.Collapsed;
                    break;
                case EditorMode.CompetitiveProgramming:
                    EditorControl.EnableIntellisense = false;
                    CPPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private async void SearchCPSolution_Click(object sender, RoutedEventArgs e)
        {
            string questionNumber = CPQuestionNumber.Text;
            string platform = (CPPlatform.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;
            string language = (CPLanguage.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(questionNumber) ||
                string.IsNullOrWhiteSpace(platform) ||
                string.IsNullOrWhiteSpace(language))
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Input Error",
                    Content = "Please enter a valid question number, platform, and language.",
                    CloseButtonText = "OK"
                };
                await errorDialog.ShowAsync();
                return;
            }

            // Use the CP query service to fetch the solution.
            var solution = await _cpModeManager.GetSolutionAsync(questionNumber, platform, language);

            // Display the fetched solution in the editor.
            EditorControl.Document.SetText(Microsoft.UI.Text.TextSetOptions.None, solution);
        }
    }
}
