using CommunityToolkit.Mvvm.Input;
using RestPunk.Interfaces;
using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace RestPunk.ViewModels
{
    public class SavedQueryViewModel : ViewModelBase
    {
        public QueryLayoutViewModel queryLayoutViewModel;

        public ObservableCollection<ITreeItem> QueryNodes { get; set; }

        public SavedQueryViewModel(QueryLayoutViewModel queryLayoutViewModel)
        {
            this.queryLayoutViewModel = queryLayoutViewModel;

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
    }
}
