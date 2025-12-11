using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace RestPunk.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ThemeMenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Application.Current is App app)
            {
                app.RequestedThemeVariant = app.ActualThemeVariant == ThemeVariant.Light ? ThemeVariant.Dark : ThemeVariant.Light;
            }
        }
    }
}