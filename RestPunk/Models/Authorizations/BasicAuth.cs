using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models.Authorizations
{
    public class BasicAuth : AuthorizationOption
    {
        public override AuthOptionEnum AuthOption { get; } = AuthOptionEnum.Basic;
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
