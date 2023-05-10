namespace UniFi.Core.Services;

public interface IUserBandwidthProfileGroupService : IService
{
    /// <summary>
    /// Create user group
    /// </summary>
    /// <param name="item">User group model</param>
    public Task<OperationResult<UserBandwidthProfileModel>> CreateUserGroup(UserBandwidthProfileModel item);

    /// <summary>
    /// Modify user group
    /// </summary>
    /// <param name="item">User group model</param>
    public Task<OperationResult<UserBandwidthProfileModel>> EditUserGroup(UserBandwidthProfileModel item);

    /// <summary>
    /// Delete user group
    /// </summary>
    /// <param name="item">User group model</param>
    public Task<OperationResult> DeleteUserGroup(UserBandwidthProfileModel item);

    /// <summary>
    /// Get all user group
    /// </summary>
    public Task<OperationResultList<UserBandwidthProfileModel>> GetAllUserGroup();
}