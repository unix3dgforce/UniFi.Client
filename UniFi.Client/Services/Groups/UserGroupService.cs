namespace UniFi.Client.Services;

public class UserGroupService : BaseService, IUserGroupService
{
    private RepositoryBase Repository { get; }

    public UserGroupService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/usergroup");
    }
    
    public async Task<OperationResult<UserGroupModel>> CreateUserGroup(UserGroupModel item)
    {
        return await Repository.Add(item);
    }

    public async Task<OperationResult<UserGroupModel>> EditUserGroup(UserGroupModel item)
    {
        return await Repository.Update(item);
    }

    public async Task<OperationResult> DeleteUserGroup(UserGroupModel item)
    {
        return await Repository.Delete(item);
    }

    public async Task<OperationResultList<UserGroupModel>> GetAllUserGroup()
    {
        return await Repository.GetAll<UserGroupModel>();
    }
}