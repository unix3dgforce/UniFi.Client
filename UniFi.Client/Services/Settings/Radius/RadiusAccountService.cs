namespace UniFi.Client.Services;

public class RadiusAccountService : BaseService, IRadiusAccountService
{
    private RepositoryBase Repository { get; }
    
    public RadiusAccountService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/account");
    }

    public async Task<OperationResult<RadiusUserModel>> CreateRadiusAccount(RadiusUserModel item)
    {
        return await Repository.Add(item);
    }

    public async Task<OperationResult<RadiusUserModel>> EditRadiusAccount(RadiusUserModel item)
    {
        return await Repository.Update(item);
    }

    public async Task<OperationResult> DeleteRadiusAccount(RadiusUserModel item)
    {
        return await Repository.Delete(item);
    }

    public async Task<OperationResultList<RadiusUserModel>> GetAllRadiusAccount()
    {
        return await Repository.GetAll<RadiusUserModel>();
    }
}