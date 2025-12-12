using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using RestPunk.Interfaces;
using RestPunk.Observers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class QueryFolder : ObservableObject,  ITreeItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private string _name = "New Folder";
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<ITreeItem> Children { get; set; } = new ObservableCollection<ITreeItem>();

        [JsonIgnore]
        public Bitmap Icon
        {
            get
            {
                if (ConfigurationManager.IsDarkTheme)
                {                    
                    return IsExpanded ?
                        new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/Inverted/folder-open-solid-full.png")))
                        : new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/Inverted/folder-solid-full.png")));                    
                }
                else
                {
                    return IsExpanded ? 
                        new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/folder-open-solid-full.png")))
                        : new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/folder-solid-full.png"))); 					
                }
            }
        }

        private bool _isExpanded = true;        

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (SetProperty(ref _isExpanded, value))
                {
                    OnPropertyChanged(nameof(Icon));                    
                }
            }
        }   
        
        public QueryFolder()
        {
			var themeChangeObservable = Application.Current.GetObservable(Application.ActualThemeVariantProperty);
            themeChangeObservable.Subscribe(new ThemeObserver(() =>
            {
                OnPropertyChanged(nameof(Icon)); 
            }));
		}
    }
}
