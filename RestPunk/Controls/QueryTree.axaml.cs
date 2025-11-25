using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RestPunk.Models;
using RestPunk.ViewModels;

namespace RestPunk.Controls;

public partial class QueryTree : UserControl
{
    private object? selectedItem;
    public QueryTree()
    {
        InitializeComponent();
    }

    private void TreeView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (this.DataContext is SavedQueryViewModel viewModel)
        {
            selectedItem = e.AddedItems?[0];
            viewModel.SelectedItem = selectedItem;
        }
        
    }

    private void TreeViewItem_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (sender is StackPanel tvi && tvi.DataContext is SavedQuery node && this.DataContext is SavedQueryViewModel viewModel)
        {
            viewModel.QueryLayoutViewModel.AddTab(node);            
        }
    }
}