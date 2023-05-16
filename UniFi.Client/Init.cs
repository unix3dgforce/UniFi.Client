namespace UniFi.Client;

public static class Init
{
    public static void AddUniFiClientServices(this IServiceCollection services)
    {
        services.AddSingleton<IConfigService, ConfigService>();
        services.AddSingleton<ICacheService, MemoryCacheService>();
        services.AddScoped<ISiteService, SiteService>();
        services.AddScoped<IDeviceService, DeviceService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IBackupService, BackupService>();
        services.AddScoped<IAccessPointService, AccessPointService>();
        services.AddScoped<IUserBandwidthProfileGroupService, UserBandwidthProfileGroupService>();
        services.AddScoped<IFirewallGroupService, FirewallGroupService>();
        services.AddScoped<INetworkConfigService, NetworkConfigService>();
        services.AddScoped<IRadiusProfileService, RadiusProfileService>();
        services.AddScoped<IRadiusAccountService, RadiusAccountService>();
        services.AddScoped<IDynamicDnsService, DynamicDnsService>();
        services.AddScoped<ISettingsService, SettingsService>();
        services.AddSingleton<RestClient>();
        services.AddSingleton<IUniFiClient, UniFiClient>();
    }
}