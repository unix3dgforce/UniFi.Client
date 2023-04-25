using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace UniFi.Client.Services;

public class ConfigService : IConfigService
{
    public AppConfigModel AppConfig { get; }

    public ConfigService(IConfiguration configuration, IOptions<AppConfigModel> appConfig)
    {
        if (appConfig.Value == null)
        {
            AppConfig = new AppConfigModel();
            return;
        }

        AppConfig = new AppConfigModel
        {
            Endpoint = appConfig.Value.Endpoint,
            Credential = appConfig.Value.Credential
        };
    }
}