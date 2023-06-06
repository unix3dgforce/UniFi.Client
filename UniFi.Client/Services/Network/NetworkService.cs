namespace UniFi.Client.Services;

public class NetworkService : BaseService, INetworkService
{
    public NetworkService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }

    private IEnumerable<NetworkModel> ApplyNetworkFilter(IEnumerable<NetworkModel> enumerable, WiredNetworkFilter filter)
    {
        return enumerable;
    }
    
    private IEnumerable<WirelessNetworkModel> ApplyWirelessFilter(IEnumerable<WirelessNetworkModel> enumerable, WirelessNetworkFilter filter)
    {
        if (filter == null)
            return enumerable;

        if (filter.IsEnabled.HasValue)
            enumerable = enumerable.Where(r => r.IsEnabled == filter.IsEnabled);
        
        if (filter.IsGuest.HasValue)
            enumerable = enumerable.Where(r => r.IsGuest == filter.IsGuest && r.IsSSIDHidden == false);

        if (filter.IsSSIDHidden.HasValue)
            enumerable = enumerable.Where(r => r.IsSSIDHidden == filter.IsSSIDHidden);

        return enumerable;
    }

    private async Task<OperationResultList<TModel>> GetNetwork<TModel, TFilter>(string uri, Func<IEnumerable<TModel>, TFilter, IEnumerable<TModel>> funcFilter, TFilter filter) 
        where TModel: BaseModel, new()
    {
        var networks = await TryGetAsync<TModel>(uri);
        if (networks.Result != OperationStatus.Success)
            return networks;
        
        return new OperationResultList<TModel>
        {
            Result = OperationStatus.Success,
            Values = funcFilter(networks.Values, filter).ToList()
        };
    }

    public async Task<OperationResultList<NetworkModel>> GetWiredNetwork(WiredNetworkFilter filter = null)
    {
        return await GetNetwork<NetworkModel, WiredNetworkFilter>($"api/s/{SiteId}/rest/networkconf", ApplyNetworkFilter, filter);
    }

    public async Task<OperationResultList<WirelessNetworkModel>> GetWirelessNetwork(WirelessNetworkFilter filter = null)
    {
        return await GetNetwork<WirelessNetworkModel, WirelessNetworkFilter>($"api/s/{SiteId}/rest/wlanconf", ApplyWirelessFilter, filter);
    }
}