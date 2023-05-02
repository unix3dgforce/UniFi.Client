using UniFi.Core;

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
    
    public async Task<OperationResult> ForceProvision(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr", new { Mac = macAddress, Cmd = "force-provision" });
    }

    public async Task<OperationResult> RestartDevice(string macAddress, RebootType rebootType = RebootType.Soft)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr", new { Mac = macAddress, RebootType = rebootType, Cmd = "restart" });
    }

    public async Task<OperationResult> DeleteDevice(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/sitemgr", new { Mac = macAddress, Cmd = "delete-device" });
    }

    public async Task<OperationResult> UpgradeDevice(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);
        
        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr/upgrade", new { Mac = macAddress });
    }

    public async Task<OperationResult> UpgradeDeviceExternal(string macAddress, string firmwareUrl)
    {
        if (UrlUtils.IsValidUrl(firmwareUrl).Result != OperationStatus.Success)
            return OperationResult.Fail(Resources.Validate_Error_FirmwareUrl);
        
        var result = StringUtils.CheckMacAddress(macAddress);
        
        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr/upgrade-external", new { Mac = macAddress, Url = firmwareUrl });
    }

    public async Task<OperationResult> LedOverrideMode(string deviceId, OverrideModeEnum mode)
    {
        if (string.IsNullOrEmpty(deviceId))
            return OperationResult.Fail();

        return await TryPutAsync($"api/s/{SiteId}/rest/device/{deviceId}", new { LedOverride = mode });
    }
}