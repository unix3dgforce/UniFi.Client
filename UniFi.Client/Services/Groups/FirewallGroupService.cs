namespace UniFi.Client.Services;

public class FirewallGroupService : BaseService, IFirewallGroupService
{
    public FirewallGroupService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }

    public async Task<OperationResult<FirewallGroupModel>> CreateFirewallGroup(string groupName, FirewallGroupType groupType, IList<string> groupMembers)
    {
        if (string.IsNullOrEmpty(groupName))
            return OperationResult<FirewallGroupModel>.Fail(Resources.Groups_Error_GroupName_NotEmpty);
        
        var group = await CheckExistsGroup(GetAllFirewallGroup, groupName);
        if (group.Result == OperationStatus.Failed)
            return group;
        
        if (group.Value != null)
            return OperationResult<FirewallGroupModel>.Fail(string.Format(Resources.FirewallGroup_Error_AlreadyExist, groupName));

        if (!groupMembers.Any())
            return OperationResult<FirewallGroupModel>.Fail(Resources.FirewallGroup_Error_NotEmpty_Members);

        var payload = new FirewallGroupModel
        {
            Name = groupName,
            Type = groupType,
            Members = groupMembers
        };
        
        return await CreateOrUpdate(TryPostAsync<FirewallGroupModel>, $"api/s/{SiteId}/rest/firewallgroup", payload);
    }

    public async Task<OperationResult<FirewallGroupModel>> EditFirewallGroup(string groupId, string groupName, IList<string> groupMembers)
    {
        if (string.IsNullOrEmpty(groupId))
            return OperationResult<FirewallGroupModel>.Fail(Resources.Groups_Error_GroupId_NotEmpty);
        
        var group = await CheckExistsGroup(GetAllFirewallGroup, groupId, true);
        if (group.Result == OperationStatus.Failed)
            return group;
        
        if (group.Value == null)
            return OperationResult<FirewallGroupModel>.Fail(string.Format(Resources.FirewallGroup_Error_NotFound_Id, groupId));
        
        var payload = group.Value;
        if (!string.IsNullOrEmpty(groupName))
            payload.Name = groupName;

        if (groupMembers.Any())
            payload.Members = groupMembers;
        
        return await CreateOrUpdate(TryPutAsync<FirewallGroupModel>, $"api/s/{SiteId}/rest/firewallgroup/{payload.Id}", payload);
    }

    public async Task<OperationResult> DeleteFirewallGroup(string groupId)
    {
        if (string.IsNullOrEmpty(groupId))
            return OperationResult<UserGroupModel>.Fail(Resources.Groups_Error_GroupId_NotEmpty);
        
        var group = await CheckExistsGroup(GetAllFirewallGroup, groupId, true);
        if (group.Result != OperationStatus.Success || group.Value == null)
            return OperationResult.Fail(string.Format(Resources.FirewallGroup_Error_NotFound_Id, groupId));
        
        return await TryDeleteAsync($"api/s/{SiteId}/rest/firewallgroup/{groupId}");
    }

    public async Task<OperationResultList<FirewallGroupModel>> GetAllFirewallGroup()
    {
        return await TryGetAsync<FirewallGroupModel>($"api/s/{SiteId}/rest/firewallgroup");
    }
    
    private async Task<OperationResult<FirewallGroupModel>> CreateOrUpdate(Func<string, object, Task<OperationResultList<FirewallGroupModel>>> func, string resource, object body = null)
    {
        var response = await func(resource, body);

        if (response.Result != OperationStatus.Success || response.Values.First() == null)
            return OperationResult<FirewallGroupModel>.Fail(Resources.FirewallGroup_Error);

        return new OperationResult<FirewallGroupModel>
        {
            Result = OperationStatus.Success,
            Value = response.Values.First()
        };
    }
}