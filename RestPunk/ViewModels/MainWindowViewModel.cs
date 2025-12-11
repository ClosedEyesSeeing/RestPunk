using Avalonia;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Styling;
using RestPunk.Models;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace RestPunk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ConfigurationManager ConfigManager { get; private set; }

        public SavedQueryViewModel SavedQueries { get; set; }

        public IBrush SliderColor { get; set; } = Brushes.DarkSlateGray;

        public QueryLayoutViewModel QueryLayout { get; private set; }

        public MainWindowViewModel()
        {
            QueryLayout = new QueryLayoutViewModel();
            ConfigManager = new ConfigurationManager();

			if (Application.Current is App app)
			{
				app.RequestedThemeVariant = ConfigManager.Configuration.CurrentTheme.ParseThemeVariant();
			}

			string jsonIn = File.ReadAllText(ConfigManager.Configuration.CurrentCollectionPath);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            QueryCollection? loadedCollection = JsonSerializer.Deserialize<QueryCollection>(jsonIn, options);
            SavedQueries = new SavedQueryViewModel(QueryLayout, loadedCollection);			
		}
    }
}
