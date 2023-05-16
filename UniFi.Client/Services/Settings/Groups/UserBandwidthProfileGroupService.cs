namespace UniFi.Client.Services;

public class UserBandwidthProfileGroupService : BaseService, IUserBandwidthProfileGroupService
{
    private RepositoryBase Repository { get; }

    public UserBandwidthProfileGroupService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/usergroup");
    }
    
    public async Task<OperationResult<UserBandwidthProfileModel>> CreateUserGroup(UserBandwidthProfileModel item)
    {
        return await Repository.Add(item);
    }

    public async Task<OperationResult<UserBandwidthProfileModel>> EditUserGroup(UserBandwidthProfileModel item)
    {
        return await Repository.Update(item);
    }

    public async Task<OperationResult> DeleteUserGroup(UserBandwidthProfileModel item)
    {
        return await Repository.Delete(item);
    }

    public async Task<OperationResultList<UserBandwidthProfileModel>> GetAllUserGroup()
    {
        return await Repository.GetAll<UserBandwidthProfileModel>();
    }
}