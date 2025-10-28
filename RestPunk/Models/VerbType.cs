using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public static class VerbType
    {
        public static string Get = "GET";
        public static string Post = "POST";
        public static string Put = "PUT";
        public static string Delete = "DELETE";
        public static string Patch = "PATCH";
        public static string Head = "HEAD";
        public static string Connect = "CONNECT";
        public static string Options = "OPTIONS";
        public static string Trace = "TRACE";

        public static ICollection<string> VerbTypes = new List<string>
        {
            Get, Post, Put, Delete, Patch, Head, Connect, Options, Trace
        };
    }
}
