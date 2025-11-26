using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class QueryResponse : ObservableObject
    {
        private string _stringContent;
        public string StringContent { get => _stringContent; set => SetProperty(ref _stringContent, value); }
        private string _statusCode;
        public string StatusCode { get => _statusCode; set => SetProperty(ref _statusCode, value); }
        private List<Header> _headers;
        public List<Header> Headers { get => _headers; set => SetProperty(ref _headers, value); }
        private DateTime _dateRan;
        public DateTime DateRan { get => _dateRan; set => SetProperty(ref _dateRan, value); }

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
