using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RestPunk.Models;
using RestPunk.ViewModels;

namespace RestPunk.Controls;

public partial class QueryTree : UserControl
{
    public QueryTree()
    {
        InitializeComponent();
    }

    private void TreeView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {

    }

    private void TreeViewItem_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (sender is StackPanel tvi && tvi.DataContext is SavedQuery node && this.DataContext is SavedQueryViewModel viewModel)
        {
            viewModel.queryLayoutViewModel.AddTab(node);            
        }
    }
}