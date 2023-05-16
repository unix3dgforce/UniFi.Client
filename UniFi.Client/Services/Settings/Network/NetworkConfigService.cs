namespace UniFi.Client.Services;

public class NetworkConfigService : BaseService, INetworkConfigService
{
    private RepositoryBase Repository { get; }

    public NetworkConfigService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/networkconf", RepositoryMethodAccess.GetAll);
    }

    public async Task<OperationResultList<BaseExtendModel>> GetAllNetworkConfig()
    {
        return await Repository.GetAll<BaseExtendModel>();
    }
}