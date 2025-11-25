using RestPunk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class SavedQuery : ITreeItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Uri { get; set; }
        public string HttpVerb { get; set; }

        public AuthorizationOption AuthorizationOption { get; set; }
        public QueryParams Params { get; set; }
        public QueryHeaders Headers { get; set; }
        public QueryBody Body { get; set; }
        
        public bool IsExpanded { get; set; } = false;

        public override string ToString()
        {
            return $"[{HttpVerb}] {Name}";
        }

    }
}
