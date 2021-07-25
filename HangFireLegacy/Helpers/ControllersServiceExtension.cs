using System;
using System.Linq;
using System.Web.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HangFireLegacy.Helpers
{
    public static class ControllersServiceExtension
    {
        public static IServiceCollection AddControllers(this IServiceCollection services)
        {
            var controllerTypes = typeof(Startup).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(ApiController).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}
