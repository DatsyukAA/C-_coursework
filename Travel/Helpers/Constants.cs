using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Helpers
{
    public static class Constants
    {
            public static class JwtClaimIndentifiers
            {
                public const string Rol = "rol", Id = "id";
            }
            public static class JwtClaims
            {
                public static readonly string[] ApiAccessRoles = { "user","client","operator","admin" };
            }
    }
}
