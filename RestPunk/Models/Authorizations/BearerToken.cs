using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models.Authorizations
{
    public class BearerToken : AuthorizationOption
    {
        public override AuthOptionEnum AuthOption { get; } = AuthOptionEnum.Bearer;
        public string Token { get; set; }

        public string Prefix { get; set; } = "Bearer";

        public override string ToString()
        {
            return $"{Prefix} {Token}";
        }
    }
}
