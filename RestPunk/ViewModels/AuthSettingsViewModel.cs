using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestPunk.Observers;

namespace RestPunk.ViewModels
{
    public class AuthSettingsViewModel : ViewModelBase
	{
        private IBrush _outlineColor = Brushes.White;
        public IBrush OutlineColor 
        {
            get => _outlineColor;
            set
            {
                SetProperty(ref _outlineColor, value);
            }
        }        

        public AuthSettingsViewModel()
        {
			ThemeChangeObservable.Subscribe(new ThemeObserver(() =>
			{                
                if (ConfigurationManager.IsDarkTheme)
					OutlineColor = Brushes.White;
                else
					OutlineColor = Brushes.Black;                                
			}));
		}
    }
}
