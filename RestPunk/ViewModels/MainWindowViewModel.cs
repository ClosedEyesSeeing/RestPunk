namespace RestPunk.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public SavedQueryViewModel SavedQueries { get; set; }

        public MainWindowViewModel()
        {
            SavedQueries = new SavedQueryViewModel();
        }
    }
}
