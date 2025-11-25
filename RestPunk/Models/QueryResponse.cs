using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class QueryResponse
    {
        public string StringContent { get; set; }
        public string StatusCode { get; set; }
        public List<Header> Headers { get; set; }
        public DateTime DateRan { get; set; }

        public QueryResponse()
        {
            Headers = new List<Header>();
        }

        public async void ParseResponse(HttpResponseMessage response)
        {
            StringContent = await response.Content.ReadAsStringAsync();
            foreach(var header in response.Content.Headers)
            {
                Headers.Add(new Header { Key = header.Key, Value = header.Value.FirstOrDefault() });
            }
            
            StatusCode = $"{response.StatusCode.ToString()} ({(int)response.StatusCode})";
            DateRan = DateTime.Now;
        }
    }
}
