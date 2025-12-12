using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using RestPunk.ViewModels;

namespace RestPunk.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object? sender, WindowClosingEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.Window_Closing(sender, e);
            }
        }
    }
}