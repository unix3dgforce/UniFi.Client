namespace UniFi.Client;

internal class UniFiClient : IUniFiClient
{
    public IConfigService ConfigService { get; init; }
    public ISiteService SiteService { get; init; }
    public IClientService ClientService { get; init; }
    public IDeviceService DeviceService { get; init; }
    public IAccessPointService AccessPointService { get; init; }
    public IBackupService BackupService { get; init; }
    public IUserBandwidthProfileGroupService UserBandwidthProfileGroupService { get; init; }
    public IFirewallGroupService FirewallGroupService { get; init; }
    public INetworkConfigService NetworkConfigService { get; init; }
    public IRadiusProfileService RadiusProfileService { get; init; }
    public IRadiusAccountService RadiusAccountService { get; init; }
    public IDynamicDnsService DynamicDnsService { get; init; }
    public ISettingsService SettingsService { get; init; }
    public INetworkService NetworkService { get; init; }

    public UniFiClient(
        IConfigService configService, 
        ISiteService controllerService,
        IClientService clientService,
        IDeviceService deviceService,
        IAccessPointService accessPointService,
        IBackupService backupService,
        IUserBandwidthProfileGroupService userBandwidthProfileGroupService,
        IFirewallGroupService firewallGroupService,
        INetworkConfigService networkConfigService,
        IRadiusProfileService radiusProfileService,
        IRadiusAccountService radiusAccountService,
        IDynamicDnsService dynamicDnsService,
        ISettingsService settingsService,
        INetworkService networkService)
    {
        ConfigService = configService;
        SiteService = controllerService;
        ClientService = clientService;
        DeviceService = deviceService;
        AccessPointService = accessPointService;
        BackupService = backupService;
        UserBandwidthProfileGroupService = userBandwidthProfileGroupService;
        FirewallGroupService = firewallGroupService;
        NetworkConfigService = networkConfigService;
        RadiusProfileService = radiusProfileService;
        RadiusAccountService = radiusAccountService;
        DynamicDnsService = dynamicDnsService;
        SettingsService = settingsService;
        NetworkService = networkService;
    }
}