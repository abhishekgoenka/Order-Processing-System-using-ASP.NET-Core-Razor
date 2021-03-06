﻿using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Data;
using OrderProcessingSystem.Data.Helpers;

namespace OrderProcessingSystem.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // inject framework services.
            services.AddScoped(
                config => new DBConnectionString(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<RepositoryFactories, RepositoryFactories>();
            services.AddScoped<IRepositoryProvider, RepositoryProvider>();
            services.AddScoped<IOrderProcessingUow, OrderProcessingUow>();

            //Whether or not a user wants a LanguageViewLocationExpander in this application, 
            //AddViewLocalization method is the one-stop shop for registering IHtmlLocalizer<T>, IStringLocalizer<T>, 
            //and IViewLocalizer in an MVC application
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);


            services.Configure<LocalizationOptions>(options => { options.ResourcesPath = "Resources"; });

            // supported culture
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SupportedUICultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-MX"),
                    new CultureInfo("de-DE")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies"
            });

            //This will clear any previous claim type maps.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                AuthenticationScheme = "oidc",
                Authority = "https://localhost:44392/",
                RequireHttpsMetadata = true,
                ClientId = "OrderProcessingSystemCORE",
                Scope = {"openid", "profile", "roles"},
                ResponseType = "code id_token",
                SignInScheme = "Cookies",
                SaveTokens = true,
                ClientSecret = "secret",
                GetClaimsFromUserInfoEndpoint = true,
                Events = new OpenIdConnectEvents
                {
                    OnTokenValidated = tokenValidatedContext =>
                    {
                        //remove unused claims
                        var identity = tokenValidatedContext.Ticket.Principal.Identity as ClaimsIdentity;
                        if (identity != null)
                        {
                            var subjectClaim = identity.Claims.FirstOrDefault(s => s.Type == "sub");

                            var newClaimIdentity = new ClaimsIdentity(tokenValidatedContext.Ticket.AuthenticationScheme,
                                "given_name", "role");
                            newClaimIdentity.AddClaim(subjectClaim);
                            tokenValidatedContext.Ticket =
                                new AuthenticationTicket(new ClaimsPrincipal(newClaimIdentity),
                                    tokenValidatedContext.Ticket.Properties,
                                    tokenValidatedContext.Ticket.AuthenticationScheme);
                        }
                        return Task.FromResult(0);
                    },

                    OnUserInformationReceived = userInformationReceivedContext =>
                    {
                        return Task.FromResult(0);
                    }
                }
            });

            app.UseStaticFiles();
            app.UseRequestLocalization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}