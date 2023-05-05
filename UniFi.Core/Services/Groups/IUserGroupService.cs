namespace UniFi.Core.Services;

public interface IUserGroupService : IService
{
    /// <summary>
    /// Create user group
    /// </summary>
    /// <param name="groupName">name of the user group</param>
    /// <param name="downloadLimitSpeed">limit download bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
    /// <param name="uploadLimitSpeed">limit upload bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
    public Task<OperationResult<UserGroupModel>> CreateUserGroup(string groupName, int downloadLimitSpeed = -1, int uploadLimitSpeed = -1);

    /// <summary>
    /// Modify user group
    /// </summary>
    /// <param name="groupId">Id user group (_id)</param>
    /// <param name="groupName">name of the user group</param>
    /// <param name="downloadLimitSpeed">limit download bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
    /// <param name="uploadLimitSpeed">limit upload bandwidth in Kbps (default = -1, which sets bandwidth to unlimited)</param>
    public Task<OperationResult<UserGroupModel>> EditUserGroup(string groupId, string groupName, int downloadLimitSpeed = -1, int uploadLimitSpeed = -1);

    /// <summary>
    /// Delete user group
    /// </summary>
    /// <param name="groupId">name of the user group</param>
    public Task<OperationResult> DeleteUserGroup(string groupId);

    /// <summary>
    /// Get all user group
    /// </summary>
    public Task<OperationResultList<UserGroupModel>> GetAllUserGroup();
}