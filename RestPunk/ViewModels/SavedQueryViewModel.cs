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

        private ObservableCollection<ITreeItem> queryNodes;
        public ObservableCollection<ITreeItem> QueryNodes { get => queryNodes; set
            {
                SetProperty(ref queryNodes, value);
            }
        }

        public SavedQueryViewModel(QueryLayoutViewModel queryLayoutViewModel, QueryCollection collection = null)
        {
            this.QueryLayoutViewModel = queryLayoutViewModel;

            OnAddFolder = new PunkRelayCommand(AddFolder);
            OnAddQuery = new PunkRelayCommand(AddNewQuery);
            OnSaveCollection = new PunkRelayCommand(SaveCollection);
            QueryLayoutViewModel.OnUpdateQuery = new PunkRelayCommand(UpdateQuery);

            QueryNodes = new ObservableCollection<ITreeItem>();

            if (collection != null)
            {
                QueryNodes = collection.Nodes;
            }
        }

        public void UpdateQuery(object? selectedItem)
        {
            if (selectedItem is SavedQuery query)
            {
                var node = QueryNodes.FirstOrDefault(n => n.Id == query.Id);
                if (node != null && node is SavedQuery savedQuery)
                {
                    savedQuery.Copy(query);
                }
                else
                {
                    foreach(var folder in QueryNodes.Where(p => p is QueryFolder))
                    {
                        node = Find(folder, p => p.Id == query.Id && p is SavedQuery);
                        if (node != null && node is SavedQuery sQuery)
                        {
                            sQuery.Copy(query);
                        }
                    }
                }
            }
        }

        private ITreeItem Find(ITreeItem currentNode, Func<ITreeItem, bool> idPredicate)
        {
            if (currentNode is QueryFolder folder)
            {
                var query = folder.Children.FirstOrDefault(idPredicate);
                if (query != null)
                {
                    return query;
                }
                foreach(var childFolder in  folder.Children.Where(p => p is QueryFolder))
                {
                    query = Find(childFolder, idPredicate);
                    if (query != null) return query;
                }
            }
            return null;
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
