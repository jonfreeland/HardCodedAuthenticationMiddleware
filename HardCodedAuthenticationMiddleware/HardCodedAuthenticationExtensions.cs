using Microsoft.AspNet.Builder;
using Microsoft.Framework.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardCodedAuthenticationMiddleware {
    public static class HardCodedAuthenticationExtensions {
        public static IApplicationBuilder UseHardCodedAuthentication(this IApplicationBuilder app, Action<HardCodedAuthenticationOptions> configureOptions = null, string optionsName = "") {
            return app.UseMiddleware<HardCodedAuthenticationMiddleware>(
                new ConfigureOptions<HardCodedAuthenticationOptions>(configureOptions ?? (o => { })) {
                    Name = optionsName
                }
            );
        }
    }
}
