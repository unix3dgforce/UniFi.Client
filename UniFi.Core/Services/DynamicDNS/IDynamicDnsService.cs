namespace UniFi.Core.Services;

public interface IDynamicDnsService : IService
{
    /// <summary>
    /// Create dynamic dns record
    /// </summary>
    /// <param name="item">See DynamicDnsModel</param>
    public Task<OperationResult<DynamicDnsModel>> CreateDynamicDns(DynamicDnsModel item);

    /// <summary>
    /// Modify dynamic dns record 
    /// </summary>
    /// <param name="item">See DynamicDnsModel</param>
    public Task<OperationResult<DynamicDnsModel>> EditDynamicDns(DynamicDnsModel item);

    /// <summary>
    /// Delete dynamic dns record
    /// </summary>
    /// <param name="item">See DynamicDnsModel</param>
    public Task<OperationResult> DeleteDynamicDns(DynamicDnsModel item);

    /// <summary>
    /// Get all dynamic records 
    /// </summary>
    public Task<OperationResultList<DynamicDnsModel>> GetAllDynamicDns();

}