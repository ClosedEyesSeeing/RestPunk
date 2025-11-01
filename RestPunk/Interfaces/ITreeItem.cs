using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Interfaces
{
    public interface ITreeItem
    {
        public string Name { get; set; }

        public bool IsExpanded { get; set; }
    }
}
