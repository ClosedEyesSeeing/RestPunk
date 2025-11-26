using Avalonia.Data;
using Avalonia.Media;
using RestPunk.Models;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace RestPunk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public SavedQueryViewModel SavedQueries { get; set; }

        public IBrush SliderColor { get; set; } = Brushes.DarkSlateGray;

        public QueryLayoutViewModel QueryLayout { get; set; }

        public MainWindowViewModel()
        {
            QueryLayout = new QueryLayoutViewModel();
            string jsonIn = File.ReadAllText("defaultCollection.json");
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            QueryCollection? loadedCollection = JsonSerializer.Deserialize<QueryCollection>(jsonIn, options);
            SavedQueries = new SavedQueryViewModel(QueryLayout, loadedCollection);
            
        }
    }
}
