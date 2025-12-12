using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Styling;
using RestPunk.Models;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

namespace RestPunk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ConfigurationManager ConfigManager { get; private set; }

        public SavedQueryViewModel SavedQueries { get; set; }        

        public QueryLayoutViewModel QueryLayout { get; private set; }

		public IBrush SliderColor { get; set; } = Brushes.DarkSlateGray;

        public ICommand OnToggleTheme { get; set; }		

		public MainWindowViewModel()
        {
            QueryLayout = new QueryLayoutViewModel();
            ConfigManager = new ConfigurationManager();

			if (Application.Current is App app)
			{
				app.RequestedThemeVariant = ConfigManager.Configuration.CurrentTheme.ParseThemeVariant();
			}

			string jsonIn = File.ReadAllText(ConfigManager.Configuration.CurrentCollectionPath);

            
            QueryCollection? loadedCollection = JsonSerializer.Deserialize<QueryCollection>(jsonIn, ConfigurationManager.JsonOptions);
            SavedQueries = new SavedQueryViewModel(QueryLayout, loadedCollection);

            OnToggleTheme = new PunkRelayCommand(HandleThemeToggle);            
		}        

		public void Window_Closing(object? sender, WindowClosingEventArgs e)
		{            
			ConfigManager.Save();

			string jsonOut = JsonSerializer.Serialize(SavedQueries.Collection, ConfigurationManager.JsonOptions);

			File.WriteAllText(ConfigManager.Configuration.CurrentCollectionPath, jsonOut);			
		}

		private void HandleThemeToggle(object? _)
        {
			if (Application.Current is App app)
			{
                var variant = app.ActualThemeVariant == ThemeVariant.Light ? ThemeVariant.Dark : ThemeVariant.Light;
                app.RequestedThemeVariant = variant;
                ConfigManager.Configuration.CurrentTheme = variant.ParseThemeVariant();
			}
		}

    }
}
