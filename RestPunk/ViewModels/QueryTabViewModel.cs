using Avalonia.Controls;
using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.ViewModels
{
    public class QueryTabViewModel : TabItem
    {
        public List<string> Verbs { get; set; }

        public SavedQuery Query { get; set; }

        public QueryTabViewModel()
        {
            Query = new SavedQuery();
            Verbs = VerbType.VerbTypes.ToList();
        }

        public QueryTabViewModel(SavedQuery query)
        {
            Query = query;
            Verbs = VerbType.VerbTypes.ToList();
        }
    }
}
