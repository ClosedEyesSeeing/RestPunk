//using CommunityToolkit.Mvvm.Input;
using Avalonia.Controls;
using RestPunk.Models;
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
        PunkRelayCommand? _add;
        PunkRelayCommand? _close;

        public ObservableCollection<QueryTabViewModel> Tabs { get; } = new();

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

        public void AddTab(SavedQuery query)
        {
            if (Tabs.FirstOrDefault(t => t.Query?.Id == query?.Id) != null) return;

            var newTab = new QueryTabViewModel(query) { Header = $"{query.Name}", Content = new QueryBodyViewModel(query, this) };
            Tabs.Add(newTab);
            SelectedTab = newTab;
        }

        

        public ICommand AddTabCommand => _add ??= new PunkRelayCommand(tab =>
        {
            if (tab is not QueryTabViewModel savedTab)
            {
                var idx = Tabs.Count + 1;
                var newTab = new QueryTabViewModel { Header = $"Unnamed {idx}", Content = new QueryBodyViewModel(this) };
                Tabs.Add(newTab);
                SelectedTab = newTab;
            }
            else
            {
                var newTab = new QueryTabViewModel { Header = $"{savedTab.Name}", Content = new QueryBodyViewModel(savedTab.Query, this), Query = savedTab.Query };
                Tabs.Add(newTab);
                SelectedTab = newTab;
            }
        });
        public ICommand CloseTabCommand => _close ??= new PunkRelayCommand(tab =>
        {
            if (tab is not QueryTabViewModel qtvm) return;
            var wasSelected = ReferenceEquals(qtvm, SelectedTab);
            var index = Tabs.IndexOf(qtvm);
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
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
