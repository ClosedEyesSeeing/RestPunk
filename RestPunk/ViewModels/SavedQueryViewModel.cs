using RestPunk.Interfaces;
using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestPunk.ViewModels
{
    public class SavedQueryViewModel : ViewModelBase
    {
        public ObservableCollection<ITreeItem> QueryFolders { get; set; }

        public SavedQueryViewModel()
        {
            QueryFolders = new ObservableCollection<ITreeItem>();
            QueryFolders.Add(new QueryFolder
            {
                Name = "Test Folder",
                SavedQueries = new ObservableCollection<SavedQuery>()
                {
                    new SavedQuery
                    {
                        Name = "Test query",
                        Uri = "https://www.restpunk.com",
                        HttpVerb = VerbType.Get
                    }
                },
                ChildFolders = new ObservableCollection<QueryFolder>() 
                { 
                    new QueryFolder()
                    {
                        Name = "Child Folder",
                        SavedQueries = new ObservableCollection<SavedQuery>()
                        {
                            new SavedQuery
                            {
                                Name = "Test query 2",
                                Uri = "https://www.restpunk.com",
                                HttpVerb = VerbType.Post
                            }
                        },
                    }
                }
            });
        }
    }
}
