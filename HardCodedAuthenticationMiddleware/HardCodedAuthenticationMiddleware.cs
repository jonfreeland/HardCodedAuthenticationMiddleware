using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.Logging;
using Microsoft.Framework.WebEncoders;
using Microsoft.AspNet.Authentication;
using Microsoft.Framework.OptionsModel;

namespace HardCodedAuthenticationMiddleware {
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class HardCodedAuthenticationMiddleware : AuthenticationMiddleware<HardCodedAuthenticationOptions> {
        public HardCodedAuthenticationMiddleware(
                    RequestDelegate next,
                    IOptions<HardCodedAuthenticationOptions> options,
                    ILoggerFactory loggerFactory,
                    IUrlEncoder encoder,
                    ConfigureOptions<HardCodedAuthenticationOptions> configureOptions)
            : base(next, options, loggerFactory, encoder, configureOptions) { }

        protected override AuthenticationHandler<HardCodedAuthenticationOptions> CreateHandler() {
            return new HardCodedAuthenticationHandler();
        }
    }
}
