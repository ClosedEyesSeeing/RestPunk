using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class Header
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public Header()
        {

        }

        public Header(string key, string value, string description = "")
        {
            Key = key;
            Value = value;
            Description = description;
        }
    }
}
