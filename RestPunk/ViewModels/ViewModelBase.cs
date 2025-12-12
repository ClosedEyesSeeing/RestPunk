using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestPunk.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public IObservable<ThemeVariant> ThemeChangeObservable = Application.Current.GetObservable(Application.ActualThemeVariantProperty);        
    }
}
