using System;
using System.Configuration;
using System.Web.Http;
using HangFireLegacy.Data;
using HangFireLegacy.Helpers;
using HangFireLegacy.Services;
using Microsoft.Extensions.DependencyInjection;
using Owin;

namespace HangFireLegacy
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            //var container = new UnityContainer();
            var services = new ServiceCollection();
             ConfigureServices(services);
             var provider = services.BuildServiceProvider();
            //config.DependencyResolver = new UnityResolver(container);
            config.DependencyResolver = new DependencyResolver(provider);
            //  Enable attribute based routing
            //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            Configure(app, provider);

            app.UseWebApi(config);
        }

        public void ConfigureServices(ServiceCollection services)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            services.AddControllers();
            services.AddScoped<IRepository, Repository>();
            services.AddHttpClient<ITimeSlotService, TimeSlotService>(client =>
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl1"]);
            });
            services.AddHttpClient<IAgentLookupService, AgentLookupService>(client =>
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl2"]);
            });

            services.AddScoped(x=> new HangFireLegacyContext(connectionString));
            //services.AddHangFire(connectionString,"HangFire");
            
        }

        public void Configure(IAppBuilder app, IServiceProvider provider)
        {
            //app.UseHangFireService(provider);
            //app.UseHangfireDashboard();
        }
    }
}
