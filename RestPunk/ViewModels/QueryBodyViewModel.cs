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
        private QueryLayoutViewModel parentViewModel;

        public List<string> Verbs { get; } = VerbType.VerbTypes.ToList();

        public SavedQuery Query { get; set; }
        public QueryBody QueryBody { get; set; }


        public QueryBodyViewModel(QueryLayoutViewModel parentVm)
        {
            parentViewModel = parentVm;
            Query = new SavedQuery();
        }

        public QueryBodyViewModel(SavedQuery query, QueryLayoutViewModel parentVm)
        {
            parentViewModel = parentVm;
            Query = query;
        }

        
    }
}
