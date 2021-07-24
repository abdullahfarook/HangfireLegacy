using System.Configuration;
using System.Web.Http;
using Hangfire;
using Hangfire.Storage.MySql;
using HangFireLegacy.Data;
using HangFireLegacy.Helpers;
using HangFireLegacy.Services;
using Owin;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using GlobalConfiguration = Hangfire.GlobalConfiguration;

namespace HangFireLegacy
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            var container = new UnityContainer();
            ConfigureServices(container);
            config.DependencyResolver = new UnityResolver(container);
            //  Enable attribute based routing
            //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            Configure(app,config);
        }

        public void ConfigureServices(UnityContainer services)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            // Register dependencies
            services.RegisterType<IRepository, Repository>();
            //DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            services.RegisterType<HangFireLegacyContext>(new PerResolveLifetimeManager(),new InjectionConstructor(connectionString));
            
            // HangFire
            var options = new MySqlStorageOptions { TablesPrefix = "HangFire" };
            var storage = new MySqlStorage(connectionString, options);
            GlobalConfiguration.Configuration.UseStorage(storage);
            GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(services));

        }

        public void Configure(IAppBuilder app, HttpConfiguration configuration)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            app.UseWebApi(configuration);
        }
    }
}
