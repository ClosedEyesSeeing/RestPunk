using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public enum AuthOptionEnum
    {
        None,
        Basic,
        Bearer,
        ApiKey,
        JWTBearer
    }


    public abstract class AuthorizationOption
    {
        public abstract AuthOptionEnum AuthOption { get; }
    }
}
