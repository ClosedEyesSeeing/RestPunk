using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models.Authorizations
{
    public class JWTBearer : AuthorizationOption
    {
        public override AuthOptionEnum AuthOption { get; } = AuthOptionEnum.JWTBearer;
    }
}
