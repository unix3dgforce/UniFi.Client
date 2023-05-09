namespace UniFi.Core.Services;

public interface IRadiusAccountService : IService
{
    /// <summary>
    /// Create a Radius user account
    /// </summary>
    /// <param name="item">radius account model</param>
    public Task<OperationResult<RadiusAccountModel>> CreateRadiusAccount(RadiusAccountModel item);
    
    /// <summary>
    /// Update a Radius user account
    /// </summary>
    /// <param name="item">radius account model</param>
    public Task<OperationResult<RadiusAccountModel>> UpdateRadiusAccount(RadiusAccountModel item);

    /// <summary>
    /// Delete a Radius account
    /// NOTES: - this function/method is only supported on controller versions 5.5.19 and later
    /// </summary>
    /// <param name="item">radius account model</param>
    public Task<OperationResult> DeleteRadiusAccount(RadiusAccountModel item);
    
    /// <summary>
    /// Get all radius account
    /// NOTES: - this function/method is only supported on controller versions 5.5.19 and later
    /// </summary>
    public Task<OperationResultList<RadiusAccountModel>> GetAllRadiusAccount();
}