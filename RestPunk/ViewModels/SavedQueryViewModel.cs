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
        public ObservableCollection<QueryFolder> QueryFolders { get; set; }

        public SavedQueryViewModel()
        {
            QueryFolders = new ObservableCollection<QueryFolder>();
            QueryFolders.Add(new QueryFolder
            {
                Name = "Test Folder",
                SavedQueries = new ObservableCollection<SavedQuery>() 
                { 
                    new SavedQuery
                    {
                        Name = "Test query",
                        URI = "https://www.restpunk.com",
                        HttpVerb = "GET"
                    }
                }
            });
           

        }
    }

    public class QueryFolder
    {
        public string Name { get; set; }
        public ObservableCollection<SavedQuery> SavedQueries { get; set; }
    }

    public class SavedQuery
    {
        public string Name { get; set; }
        public string URI { get; set; }
        public string HttpVerb { get; set; }
    }
}
