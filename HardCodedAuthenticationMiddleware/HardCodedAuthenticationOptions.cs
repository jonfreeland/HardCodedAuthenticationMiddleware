using Microsoft.AspNet.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HardCodedAuthenticationMiddleware {
    public class HardCodedAuthenticationOptions : AuthenticationOptions {
        public IList<Claim> Claims { get; set; }

        public HardCodedAuthenticationOptions() {
            AuthenticationScheme = "HardCoded";
            Claims = new List<Claim>();
        }
    }
}
