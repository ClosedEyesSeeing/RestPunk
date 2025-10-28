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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public string HttpVerb { get; set; }

        public AuthorizationOptions AuthorizationOptions { get; set; }

        public QueryBody Body { get; set; }

    }
}
