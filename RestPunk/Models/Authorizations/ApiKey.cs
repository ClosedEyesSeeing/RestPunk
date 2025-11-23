using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models.Authorizations
{
    public class ApiKey : AuthorizationOption
    {
        public override AuthOptionEnum AuthOption { get; } = AuthOptionEnum.ApiKey;

        public KeyValuePair<string, string> KeyPair { get; set; }
        public AuthLocationEnum AuthLocation { get; set; } = AuthLocationEnum.Header;
    }
}
