using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public static class Constants
    {
        public const string Issuer = Audience;
        public const string Audience = "https://localhost:44374/";
        public const string Secret = "this_is_new_secret_key";
    }
}
