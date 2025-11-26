using RestPunk.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class QueryCollection
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ObservableCollection<ITreeItem> Nodes { get; set; } = new();
    }
}
