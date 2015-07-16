# HardCodedAuthenticationMiddleware

Simple ASP.NET 5 middleware that allows for hard-coding claims and automatically authenticates the user to simplify local development.

    public void ConfigureServices(IServiceCollection services) {
        /* ... */
        services.Configure<HardCodedAuthenticationOptions>(options => {
            options.Claims.Add(new Claim(ClaimTypes.Name, "Hard Coded User"));
            options.Claims.Add(new Claim(ClaimTypes.Email, "hardcodeduser@example.com"));
            options.Claims.Add(new Claim(ClaimTypes.StreetAddress, "123 Sesame Street"));
            options.Claims.Add(new Claim(ClaimTypes.HomePhone, "555-867-5309"));
            options.AutomaticAuthentication = true;
        });
        /* ... */
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory) {
    /* ... */
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
    /* ... */
    }

See the HardCodedAuthenticationTest project for more details.