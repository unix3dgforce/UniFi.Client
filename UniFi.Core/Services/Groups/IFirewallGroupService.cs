namespace UniFi.Core.Services;

public interface IFirewallGroupService : IService
{
    /// <summary>
    /// Create firewall group
    /// </summary>
    /// <param name="item">Firewall group model</param>
    public Task<OperationResult<FirewallGroupModel>> CreateFirewallGroup(FirewallGroupModel item);

    /// <summary>
    /// Update firewall group
    /// </summary>
    /// <param name="item">Firewall group model</param>
    public Task<OperationResult<FirewallGroupModel>> EditFirewallGroup(FirewallGroupModel item);
    
    /// <summary>
    /// Delete firewall group
    /// </summary>
    /// <param name="item">Firewall group model</param>
    public Task<OperationResult> DeleteFirewallGroup(FirewallGroupModel item);

    /// <summary>
    /// Get all firewall groups
    /// </summary>
    public Task<OperationResultList<FirewallGroupModel>> GetAllFirewallGroup();
}