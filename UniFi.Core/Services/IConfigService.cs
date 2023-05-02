namespace UniFi.Core.Services;

public interface IConfigService : IService
{
    public AppConfigModel AppConfig { get; }
}