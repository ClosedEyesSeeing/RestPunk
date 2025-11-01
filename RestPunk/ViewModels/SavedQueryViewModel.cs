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
        public ObservableCollection<ITreeItem> QueryNodes { get; set; }

        public SavedQueryViewModel()
        {
            QueryNodes = new ObservableCollection<ITreeItem>();
            QueryNodes.Add(new QueryFolder
            {
                Name = "Test Folder",
                Children = new ObservableCollection<ITreeItem>()
                {
                    new SavedQuery
                    {
                        Name = "Test query",
                        Uri = "https://www.restpunk.com",
                        HttpVerb = VerbType.Get
                    },
                    new QueryFolder()
                    {
                        Name = "Child Folder",
                        Children = new ObservableCollection<ITreeItem>()
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
