using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace NetCoreAppSettings
{
    class MyService : IMyService
    {
        private readonly IConfiguration _configuration;
        public MyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSettingValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        public T GetSetting<T>(string key)
        {
            return _configuration.Get<T>();
        }
    }
}
