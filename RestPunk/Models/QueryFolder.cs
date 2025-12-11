using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using RestPunk.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

        public Bitmap Icon
        {
            get
            {
                if (Application.Current?.ActualThemeVariant == ThemeVariant.Dark)
                {
                    if (IsExpanded)
                    {
                        return new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/Inverted/folder-open-solid-full.png")));
                    }

                    return new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/Inverted/folder-solid-full.png")));
                }
                else
                {
                    if (IsExpanded)
                    {
                        return new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/folder-open-solid-full.png")));
                    }

                    return new Bitmap(AssetLoader.Open(new Uri("avares://RestPunk/Assets/Icons/folder-solid-full.png")));
                }
            }
        }

        private bool _isExpanded = true;

        public event PropertyChangedEventHandler? OtherPropertyChanged;

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (SetField(ref _isExpanded, value))
                {
                    OtherPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Icon)));
                }
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OtherPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            return true;
        }
    }
}
