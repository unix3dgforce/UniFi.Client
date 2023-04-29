namespace UniFi.Client.Services;

public class DeviceService : BaseService, IDeviceService
{
    public DeviceService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }

    public async Task<OperationResult> AdoptDevice(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr", new { Mac = macAddress, Cmd = "adopt" });
    }

    public async Task<OperationResult> RestartDevice(string macAddress, RebootType rebootType = RebootType.Soft)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr", new { Mac = macAddress, Reboot_Type = rebootType, Cmd = "restart" });
    }

    public async Task<OperationResult> ForceProvision(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr", new { Mac = macAddress, Cmd = "force-provision" });
    }
}