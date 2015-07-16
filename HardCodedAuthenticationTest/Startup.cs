using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication.Facebook;
using Microsoft.AspNet.Authentication.Google;
using Microsoft.AspNet.Authentication.MicrosoftAccount;
using Microsoft.AspNet.Authentication.Twitter;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Routing;
using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using Microsoft.Framework.Runtime;
using HardCodedAuthenticationMiddleware;
using System.Security.Claims;
using Microsoft.Framework.Configuration;

namespace HardCodedAuthenticationTest {
    public class Startup {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv) {
            // Setup configuration sources.
            var configuration = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<HardCodedAuthenticationOptions>(options => {
                options.Claims.Add(new Claim(ClaimTypes.Name, "Hard Coded User"));
                options.Claims.Add(new Claim(ClaimTypes.Email, "hardcodeduser@example.com"));
                options.Claims.Add(new Claim(ClaimTypes.StreetAddress, "123 Sesame Street"));
                options.Claims.Add(new Claim(ClaimTypes.HomePhone, "555-867-5309"));
                options.AutomaticAuthentication = true;
            });
            
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory) {
            loggerfactory.AddConsole(minLevel: LogLevel.Warning);
            
            if (env.IsEnvironment("Development")) {
                ////app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            } else {
                app.UseErrorHandler("/Home/Error");
            }
            
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            if (env.IsEnvironment("Development")) {
                app.UseHardCodedAuthentication();
            } else {
                // Add authentication middleware to the request pipeline. You can configure options such as Id and Secret in the ConfigureServices method.
                // For more information see http://go.microsoft.com/fwlink/?LinkID=532715
                // app.UseFacebookAuthentication();
                // app.UseGoogleAuthentication();
                // app.UseMicrosoftAccountAuthentication();
                // app.UseTwitterAuthentication();
            }
            
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
