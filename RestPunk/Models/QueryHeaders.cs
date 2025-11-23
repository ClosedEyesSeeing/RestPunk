using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class QueryHeaders
    {
        public List<Header> Headers { get; set; }

        public QueryHeaders() 
        { 
            Headers = new List<Header>();
            LoadDefaults();
        }

        public QueryHeaders(List<Header> headers)
        {
            Headers = headers;
        }

        private void LoadDefaults()
        {
            Headers.Add(new Header("Accept", "*/*"));
            Headers.Add(new Header("Accept-Encoding", "gzip, deflate, br"));
            Headers.Add(new Header("Cache-Control", "no-cache"));
            Headers.Add(new Header("Connection", "keep-alive"));
            Headers.Add(new Header("User-Agent", "RestPunkUA/1.0.0"));
        }
    }
}
