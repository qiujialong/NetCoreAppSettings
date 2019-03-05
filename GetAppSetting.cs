using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NetCoreAppSettings
{
    public class AppSettings
    {
        private static IConfiguration _appConfiguration;

        public static string GetValue(string key)
        {
            var hostBuilder = new HostBuilder().ConfigureAppConfiguration((hostContext, configApp) =>
            {
                var hostingEnvironment = hostContext.HostingEnvironment;
                _appConfiguration = AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
            }).ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(_appConfiguration);
                services.AddSingleton<IMyService, MyService>();
            });

            var builder = hostBuilder.Build();
            var myService = builder.Services.GetService<IMyService>();
            return myService.GetSettingValue(key);
        }

        public static T GetSection<T>(string key) where T : class, new()
        {
            var hostBuilder = new HostBuilder().ConfigureAppConfiguration((hostContext, configApp) =>
            {
                var hostingEnvironment = hostContext.HostingEnvironment;
                _appConfiguration = AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
            }).ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton(_appConfiguration);
                services.AddSingleton<IMyService, MyService>();
            });

            var builder = hostBuilder.Build();
            var myService = builder.Services.GetService<IMyService>();
            return _appConfiguration.GetSection(key).Get<T>();
        }
    }
}
