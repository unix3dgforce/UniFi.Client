namespace UniFi.Client;

public interface IUniFiClient
{
    IConfigService ConfigService { get; init; }
    ISiteService SiteService { get; init; }
    IClientService ClientService { get; init; }
    IDeviceService DeviceService { get; init; }
    IAccessPointService AccessPointService { get; init; }
    IBackupService BackupService { get; init; }
    IUserBandwidthProfileGroupService UserBandwidthProfileGroupService { get; init; }
    IFirewallGroupService FirewallGroupService { get; init; }
    INetworkConfigService NetworkConfigService { get; init; }
    IRadiusProfileService RadiusProfileService { get; init; }
    IRadiusAccountService RadiusAccountService { get; init; }
    IDynamicDnsService DynamicDnsService { get; init; }
    ISettingsService SettingsService { get; set; }
}