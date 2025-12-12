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
using Avalonia.Controls;

namespace RestPunk.ViewModels
{
    public class AuthSettingsViewModel : ViewModelBase
	{
        public Dictionary<string, UserControl> AvailableAuths { get; set; }

        private IBrush _outlineColor = Brushes.White;
        public IBrush OutlineColor 
        {
            get => _outlineColor;
            set
            {
                SetProperty(ref _outlineColor, value);
            }
        }

        private UserControl _currentAuthControl;
        public UserControl CurrentAuthControl
        {
            get => _currentAuthControl;
            set => SetProperty(ref _currentAuthControl, value);
        }

        private KeyValuePair<string, UserControl> _selectedUserControl;
		public KeyValuePair<string, UserControl> SelectedUserControl
        {
            get => _selectedUserControl;
            set
            {
                CurrentAuthControl = value.Value;
                SetProperty(ref _selectedUserControl, value);
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

			AvailableAuths = new Dictionary<string, UserControl>();
            AvailableAuths.Add("Bearer Token", new BearerTokenControl());

		}
    }
}
