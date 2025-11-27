using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RestPunk.Models;

namespace RestPunk;

public partial class RenameWindow : Window
{
    public string ReturnValue { get; set; }
    public RenameWindow(QueryFolder folder)
    {
        InitializeComponent();
        folderNameBox.Text = folder.Name;
    }

    private void saveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ReturnValue = folderNameBox.Text;
        this.Close(ReturnValue);
    }

    private void cancelButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }
}