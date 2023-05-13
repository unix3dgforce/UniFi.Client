namespace UniFi.Core.Services;

public interface IRadiusAccountService : IService
{
    /// <summary>
    /// Create a Radius user account
    /// </summary>
    /// <param name="item">radius account model</param>
    public Task<OperationResult<RadiusUserModel>> CreateRadiusAccount(RadiusUserModel item);
    
    /// <summary>
    /// Update a Radius user account
    /// </summary>
    /// <param name="item">radius account model</param>
    public Task<OperationResult<RadiusUserModel>> EditRadiusAccount(RadiusUserModel item);

    /// <summary>
    /// Delete a Radius account
    /// NOTES: - this function/method is only supported on controller versions 5.5.19 and later
    /// </summary>
    /// <param name="item">radius account model</param>
    public Task<OperationResult> DeleteRadiusAccount(RadiusUserModel item);
    
    /// <summary>
    /// Get all radius account
    /// NOTES: - this function/method is only supported on controller versions 5.5.19 and later
    /// </summary>
    public Task<OperationResultList<RadiusUserModel>> GetAllRadiusAccount();
}