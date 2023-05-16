namespace UniFi.Client.Services;

public class DynamicDnsService : BaseService, IDynamicDnsService
{
    private RepositoryBase Repository { get; }
    
    public DynamicDnsService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/dynamicdns");
    }

    public async Task<OperationResult<DynamicDnsModel>> CreateDynamicDns(DynamicDnsModel item)
    {
        return await Repository.Add(item);
    }

    public async Task<OperationResult<DynamicDnsModel>> EditDynamicDns(DynamicDnsModel item)
    {
        return await Repository.Update(item);
    }

    public async Task<OperationResult> DeleteDynamicDns(DynamicDnsModel item)
    {
        return await Repository.Delete(item);
    }

    public async Task<OperationResultList<DynamicDnsModel>> GetAllDynamicDns()
    {
        return await Repository.GetAll<DynamicDnsModel>();
    }
}