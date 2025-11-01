using RestPunk.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class QueryFolder : ITreeItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public ObservableCollection<SavedQuery> SavedQueries { get; set; } = new ObservableCollection<SavedQuery>();

        //public ObservableCollection<QueryFolder> ChildFolders { get; set; } = new ObservableCollection<QueryFolder>();

        public ObservableCollection<ITreeItem> Children { get; set; } = new ObservableCollection<ITreeItem>();

        public bool IsExpanded { get; set; } = true;
    }
}
