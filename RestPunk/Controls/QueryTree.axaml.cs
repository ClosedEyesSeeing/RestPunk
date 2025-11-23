using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
}