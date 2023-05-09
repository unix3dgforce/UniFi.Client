namespace UniFi.Core.Services;

public interface IUserGroupService : IService
{
    /// <summary>
    /// Create user group
    /// </summary>
    /// <param name="item">User group model</param>
    public Task<OperationResult<UserGroupModel>> CreateUserGroup(UserGroupModel item);

    /// <summary>
    /// Modify user group
    /// </summary>
    /// <param name="item">User group model</param>
    public Task<OperationResult<UserGroupModel>> EditUserGroup(UserGroupModel item);

    /// <summary>
    /// Delete user group
    /// </summary>
    /// <param name="item">User group model</param>
    public Task<OperationResult> DeleteUserGroup(UserGroupModel item);

    /// <summary>
    /// Get all user group
    /// </summary>
    public Task<OperationResultList<UserGroupModel>> GetAllUserGroup();
}