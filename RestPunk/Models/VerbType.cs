using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public static class VerbType
    {
        public static string Get = GetConst;
        public static string Post = PostConst;
        public static string Put = PutConst;
        public static string Delete = DeleteConst;
        public static string Patch = PatchConst;
        public static string Head = HeadConst;
        public static string Connect = ConnectConst;
        public static string Options = OptionsConst;
        public static string Trace = TraceConst;

        public const string GetConst = "GET"; 
        public const string PostConst = "POST";
        public const string PutConst = "PUT";
        public const string DeleteConst = "DELETE";
        public const string PatchConst = "PATCH";
        public const string HeadConst = "HEAD";
        public const string ConnectConst = "CONNECT";
        public const string OptionsConst = "OPTIONS";
        public const string TraceConst = "TRACE";


        public static ICollection<string> VerbTypes = new List<string>
        {
            Get, Post, Put, Delete, Patch, Head, Connect, Options, Trace
        };
    }
}
