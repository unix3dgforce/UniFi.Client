namespace UniFi.Client.Services;

public class FirewallGroupService : BaseService, IFirewallGroupService
{
    private RepositoryBase Repository { get; }

    public FirewallGroupService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/firewallgroup");
    }

    public async Task<OperationResult<FirewallGroupModel>> CreateFirewallGroup(FirewallGroupModel item)
    {
        return await Repository.Add(item);
    }

    public async Task<OperationResult<FirewallGroupModel>> EditFirewallGroup(FirewallGroupModel item)
    {
        return await Repository.Update(item);
    }

    public async Task<OperationResult> DeleteFirewallGroup(FirewallGroupModel item)
    {
        return await Repository.Delete(item);
    }

    public async Task<OperationResultList<FirewallGroupModel>> GetAllFirewallGroup()
    {
        return await Repository.GetAll<FirewallGroupModel>();
    }
}