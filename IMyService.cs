using Microsoft.Extensions.Configuration;

namespace NetCoreAppSettings
{
    public interface IMyService
    {
        string GetSettingValue(string key);

        T GetSetting<T>(string key);
    }
}
