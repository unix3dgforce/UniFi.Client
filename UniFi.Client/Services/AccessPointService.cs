namespace UniFi.Client.Services;

public class AccessPointService : BaseService, IAccessPointService
{
    public AccessPointService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }

    public async Task<OperationResult> LocateAccessPoint(string macAddress, bool state)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync($"api/s/{SiteId}/cmd/devmgr", new { Mac = macAddress, Cmd = state ? "set-locate" : "unset-locate" });
    }

    public async Task<OperationResult> RenameAccessPoint(string accessPointId, string name)
    {
        if (string.IsNullOrEmpty(accessPointId))
            return OperationResult.Fail();

        return await TryPostAsync($"api/s/{SiteId}/upd/device/{accessPointId}", new { Name = name });
    }

    public async Task<OperationResult> DisableAccessPoint(string accessPointId, bool state)
    {
        if (string.IsNullOrEmpty(accessPointId))
            return OperationResult.Fail();

        return await TryPutAsync($"api/s/{SiteId}/rest/device/{accessPointId}", new { Disabled = state });
    }
}