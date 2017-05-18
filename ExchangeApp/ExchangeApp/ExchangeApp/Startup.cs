using Autofac;
using Autofac.Builder;
using Autofac.Integration.WebApi;
using ExchangeApp.API.Services;
using ExchangeApp.API.Services.Interfaces;
using ExchangeApp.Repository.Context;
using ExchangeApp.Repository.Repository;
using ExchangeApp.Repository.Repository.Interfaces;
using Market.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;

[assembly: OwinStartup(typeof(ExchangeApp.API.Startup))]
namespace ExchangeApp.API
{
    public class Startup
    {
        private readonly string connectionString = "ExchangeAppContext";

        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            //Repositories
            builder.Register(c => new AuthRepository(new ExchangeAppContext(connectionString))).As<IAuthRepository>();
            builder.Register(c => new CurrencyRepository(new ExchangeAppContext(connectionString))).As<ICurrencyRepository>();
            builder.Register(c => new WalletRepository(new ExchangeAppContext(connectionString))).As<IWalletRepository>();

            //Services
            builder.RegisterType<ExchangeAppUserService>().As<IExchangeAppUserService>();
            builder.RegisterType<CurrencyService>().As<ICurrencyService>();
            builder.RegisterType<WalletService>().As<IWalletService>();

            //WebApi Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //OAuth providers
            builder.RegisterType<SimpleAuthorizationServerProvider>()
                 .AsImplementedInterfaces<IOAuthAuthorizationServerProvider, ConcreteReflectionActivatorData>();

            var container = builder.Build();

            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureOAuth(app, container);
            WebApiConfig.Register(config);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IContainer container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = container.Resolve<IOAuthAuthorizationServerProvider>(),
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}