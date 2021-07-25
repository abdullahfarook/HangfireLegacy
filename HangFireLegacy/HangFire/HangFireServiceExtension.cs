using System;
using Hangfire;
using Hangfire.Storage.MySql;
using Microsoft.Extensions.DependencyInjection;
using Owin;

namespace HangFireLegacy.HangFire
{
    public static class HangFireServiceExtension
    {
        private static string _connectionString;
        private static string _tablePrefix;

        public static void AddHangFire(this IServiceCollection services, string connectionString,string tablePrefix = null)
        {
            _connectionString = connectionString;
            _tablePrefix = tablePrefix;
        }
        public static void UseHangFireService(this IAppBuilder app, IServiceProvider provider)
        {
            // HangFire
            var options = new MySqlStorageOptions();
            if (_tablePrefix != null) options.TablesPrefix = _tablePrefix;
            var storage = new MySqlStorage(_connectionString, options);
            GlobalConfiguration.Configuration.UseStorage(storage);
            GlobalConfiguration.Configuration.UseActivator(new HangFireContainerJobActivator(provider));
            app.UseHangfireServer();
        }
    }
}
