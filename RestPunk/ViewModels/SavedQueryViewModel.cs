using CommunityToolkit.Mvvm.Input;
using RestPunk.Interfaces;
using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;


namespace RestPunk.ViewModels
{
    public class SavedQueryViewModel : ViewModelBase
    {
        public object? SelectedItem;
        public QueryLayoutViewModel QueryLayoutViewModel;
        public ICommand OnAddQuery { get; }
        public ICommand OnAddFolder { get; }
        public ICommand OnSaveCollection { get; }

        public QueryCollection Collection { get; set; }

        public ObservableCollection<ITreeItem> QueryNodes { get; set; }

        public SavedQueryViewModel(QueryLayoutViewModel queryLayoutViewModel, QueryCollection collection = null)
        {
            this.QueryLayoutViewModel = queryLayoutViewModel;

            OnAddFolder = new PunkRelayCommand(AddFolder);
            OnAddQuery = new PunkRelayCommand(AddNewQuery);
            OnSaveCollection = new PunkRelayCommand(SaveCollection);

            QueryNodes = new ObservableCollection<ITreeItem>();

            if (collection != null)
            {
                QueryNodes = collection.Nodes;
            }
        }

        

        public void AddFolder(object? _)
        {
            var newFolder = new QueryFolder();

            if (SelectedItem != null && SelectedItem is QueryFolder folder)
            {
                folder.Children.Add(newFolder);
            }
            else
            {
                QueryNodes.Add(newFolder);
            }
        }

        public void AddNewQuery(object? _)
        {
            var query = new SavedQuery();

            if (SelectedItem != null && SelectedItem is QueryFolder folder)
            {
                folder.Children.Add(query);
                QueryLayoutViewModel.AddTab(query);
            }
            else
            {
                QueryNodes.Add(query);
                QueryLayoutViewModel.AddTab(query);
            }
        }

        public void SaveCollection(object? _)
        {
            if (Collection == null)
            {
                Collection = new QueryCollection();
                Collection.Name = "Default Collection";
            }

            Collection.Nodes = QueryNodes;

            WriteCollection();
        }

        private void WriteCollection(string path = null)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                // If you have circular references or weird objects:
                // ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            // Convert to JSON string
            string json = JsonSerializer.Serialize(Collection, options);

            // Write to a file
            if (string.IsNullOrWhiteSpace(path))
                path = "defaultCollection.json";

            File.WriteAllText(path, json);
        }
    }
}
