using CommunityToolkit.Mvvm.Input;
using RestPunk.Interfaces;
using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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


        public ObservableCollection<ITreeItem> QueryNodes { get; set; }

        public SavedQueryViewModel(QueryLayoutViewModel queryLayoutViewModel)
        {
            this.QueryLayoutViewModel = queryLayoutViewModel;

            OnAddFolder = new PunkRelayCommand(AddFolder);
            OnAddQuery = new PunkRelayCommand(AddNewQuery);

            QueryNodes = new ObservableCollection<ITreeItem>();
            QueryNodes.Add(new QueryFolder
            {
                Name = "Test Folder",
                Children = new ObservableCollection<ITreeItem>()
                {
                    new SavedQuery
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test query",
                        Uri = "https://jsonplaceholder.typicode.com/todos/1",//"https://www.restpunk.com",
                        HttpVerb = VerbType.Get
                    },
                    new QueryFolder()
                    {
                        Name = "Child Folder",
                        Children = new ObservableCollection<ITreeItem>()
                        {
                            new SavedQuery
                            {
                                Id = Guid.NewGuid(),
                                Name = "Test query 2",
                                Uri = "https://www.restpunk.com",
                                HttpVerb = VerbType.Post
                            }
                        },
                    }
                }
               
            });
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
    }
}
