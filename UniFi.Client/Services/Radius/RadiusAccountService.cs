namespace UniFi.Client.Services;

public class RadiusAccountService : BaseService, IRadiusAccountService
{
    private RepositoryBase Repository { get; }
    
    public RadiusAccountService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/account");
    }

    public async Task<OperationResult<RadiusAccountModel>> CreateRadiusAccount(RadiusAccountModel item)
    {
        return await Repository.Add(item);
    }

    public async Task<OperationResult<RadiusAccountModel>> UpdateRadiusAccount(RadiusAccountModel item)
    {
        return await Repository.Update(item);
    }

    public async Task<OperationResult> DeleteRadiusAccount(RadiusAccountModel item)
    {
        return await Repository.Delete(item);
    }

    public async Task<OperationResultList<RadiusAccountModel>> GetAllRadiusAccount()
    {
        return await Repository.GetAll<RadiusAccountModel>();
    }
}