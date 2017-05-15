using Autofac;
using Autofac.Integration.WebApi;
using ExchangeApp.API.Services;
using ExchangeApp.API.Services.Interfaces;
using ExchangeApp.Repository.Context;
using ExchangeApp.Repository.Repository;
using ExchangeApp.Repository.Repository.Interfaces;
using Microsoft.Owin;
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
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            var builder = new ContainerBuilder();

            //WebApi Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Repositories
            builder.Register(c => new AuthRepository(new ExchangeAppContext(connectionString))).As<IAuthRepository>();

            //Services
            builder.RegisterType<ExchangeAppUserService>().As<IExchangeAppUserService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

    }
}