using Avalonia.Media;
using System.Drawing;

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
            SavedQueries = new SavedQueryViewModel(QueryLayout);
            
        }
    }
}
