using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class QueryParams
    {
        public List<Parameter> Params { get; set; }

        public QueryParams()
        {
            Params = new List<Parameter>();
        }

        public QueryParams(List<Parameter> paramList)
        {
            Params = paramList;
        }
    }
}
