//using CommunityToolkit.Mvvm.Input;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestPunk.ViewModels
{
    public class QueryLayoutViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<QueryTabViewModel> Tabs { get; } =
            [
                new() { Header = "Welcome", Content = "Hello from Avalonia!" },
                new() { Header = "Test", Content = new QueryBodyViewModel() }
            ];

        private QueryTabViewModel? _selectedTab;
        public QueryTabViewModel? SelectedTab
        {
            get => _selectedTab;
            set
            {
                if (!ReferenceEquals(_selectedTab, value))
                {
                    _selectedTab = value;
                    OnPropertyChanged();
                    SelectedContent = value?.Content;
                    OnPropertyChanged("SelectedContent");
                }
            }
        }

        public object? SelectedContent { get; set; }

        public QueryLayoutViewModel()
        {
            if (Tabs.Count > 0) SelectedTab = Tabs[0];
        }

        public ICommand AddTabCommand => _add ??= new PunkRelayCommand(_ =>
        {
            var idx = Tabs.Count + 1;
            var t = new QueryTabViewModel { Header = $"Unnamed {idx}", Content = new QueryBodyViewModel() };
            Tabs.Add(t);
            SelectedTab = t;
        });
        PunkRelayCommand? _add;

        public ICommand CloseTabCommand => _close ??= new PunkRelayCommand(tab =>
        {
            if (tab is not QueryTabViewModel t) return;
            var wasSelected = ReferenceEquals(t, SelectedTab);
            var index = Tabs.IndexOf(t);
            if (index < 0) return;

            Tabs.RemoveAt(index);

            if (wasSelected && Tabs.Count > 0)
            {
                // Prefer the previous tab; fall back to last.
                var newIndex = index - 1;
                if (newIndex < 0) newIndex = 0;
                if (newIndex >= Tabs.Count) newIndex = Tabs.Count - 1;
                SelectedTab = Tabs[newIndex];
            }
        });
        PunkRelayCommand? _close;
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
