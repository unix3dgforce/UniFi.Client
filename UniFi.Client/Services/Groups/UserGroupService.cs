namespace UniFi.Client.Services;

public class UserGroupService : BaseService, IUserGroupService
{
    public UserGroupService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }
    
    public async Task<OperationResult<UserGroupModel>> CreateUserGroup(string groupName, int downloadLimitSpeed = -1, int uploadLimitSpeed = -1)
    {
        if (string.IsNullOrEmpty(groupName))
            return OperationResult<UserGroupModel>.Fail(Resources.Groups_Error_GroupName_NotEmpty);
        
        var group = await CheckExistsGroup(GetAllUserGroup, groupName);
        if (group.Result == OperationStatus.Failed)
            return group;
        
        if (group.Value != null)
            return OperationResult<UserGroupModel>.Fail(string.Format(Resources.UserGroup_Error_AlreadyExist, groupName));

        var payload = new UserGroupModel
        {
            Name = groupName,
            QosDownloadMaxLimit = downloadLimitSpeed,
            QosUploadMaxLimit = uploadLimitSpeed
        };
        
        return await CreateOrUpdate(TryPostAsync<UserGroupModel>, $"api/s/{SiteId}/rest/usergroup", payload);
    }

    public async Task<OperationResult<UserGroupModel>> EditUserGroup(string groupId, string groupName = null, int downloadLimitSpeed = -1, int uploadLimitSpeed = -1)
    {
        if (string.IsNullOrEmpty(groupId))
            return OperationResult<UserGroupModel>.Fail(Resources.Groups_Error_GroupId_NotEmpty);
        
        var group = await CheckExistsGroup(GetAllUserGroup, groupId, true);
        if (group.Result == OperationStatus.Failed)
            return group;
        
        if (group.Value == null)
            return OperationResult<UserGroupModel>.Fail(string.Format(Resources.UserGroup_Error_NotFound_Id, groupId));

        var payload = group.Value;
        if (!string.IsNullOrEmpty(groupName))
            payload.Name = groupName;

        payload.QosDownloadMaxLimit = downloadLimitSpeed;
        payload.QosUploadMaxLimit = uploadLimitSpeed;

        return await CreateOrUpdate(TryPutAsync<UserGroupModel>, $"api/s/{SiteId}/rest/usergroup/{payload.Id}", payload);
    }

    public async Task<OperationResult> DeleteUserGroup(string groupId)
    {
        if (string.IsNullOrEmpty(groupId))
            return OperationResult<UserGroupModel>.Fail(Resources.Groups_Error_GroupId_NotEmpty);
        
        var group = await CheckExistsGroup(GetAllUserGroup, groupId, true);
        if (group.Result != OperationStatus.Success || group.Value == null)
            return OperationResult.Fail(string.Format(Resources.UserGroup_Error_NotFound_Id, groupId));

        if (group.Value.DontAllowDeletion is true)
            return OperationResult.Fail(string.Format(Resources.UserGroup_Error_DeleteGroup, group.Value.Name));

        return await TryDeleteAsync($"api/s/{SiteId}/rest/usergroup/{groupId}");
    }

    public async Task<OperationResultList<UserGroupModel>> GetAllUserGroup()
    {
        return await TryPostAsync<UserGroupModel>($"api/s/{SiteId}/list/usergroup");
    }

    private async Task<OperationResult<UserGroupModel>> CreateOrUpdate(Func<string, object, Task<OperationResultList<UserGroupModel>>> func, string resource, object body = null)
    {
        var response = await func(resource, body);

        if (response.Result != OperationStatus.Success || response.Values.First() == null)
            return OperationResult<UserGroupModel>.Fail(Resources.UserGroup_Error);

        return new OperationResult<UserGroupModel>
        {
            Result = OperationStatus.Success,
            Value = response.Values.First()
        };
    }
}