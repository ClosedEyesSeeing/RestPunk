using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.ViewModels
{
    public class QueryBodyViewModel
    {
        public List<string> Verbs { get; } = VerbType.VerbTypes.ToList();

        public SavedQuery Query { get; set; }
        public QueryBody QueryBody { get; set; }


        public QueryBodyViewModel()
        {
            Query = new SavedQuery();
        }

        public QueryBodyViewModel(SavedQuery query)
        {
            Query = query;
        }

        
    }
}
