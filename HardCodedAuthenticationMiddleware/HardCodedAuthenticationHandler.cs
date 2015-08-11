using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HardCodedAuthenticationMiddleware {
    internal class HardCodedAuthenticationHandler : AuthenticationHandler<HardCodedAuthenticationOptions> {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected override async Task<AuthenticationTicket> HandleAuthenticateAsync() {
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            var id = new ClaimsIdentity("HardCoded");
            foreach (var claim in Options.Claims)
                id.AddClaim(claim);            
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(id), new AuthenticationProperties(), Options.AuthenticationScheme);
            return ticket;
        }
    }
}
