namespace UniFi.Core.Services;

public interface IFirewallGroupService : IService
{
    public Task<OperationResult<FirewallGroupModel>> CreateFirewallGroup(string groupName, FirewallGroupType groupType, IList<string> groupMembers);

    public Task<OperationResult<FirewallGroupModel>> EditFirewallGroup(string groupId, string groupName, IList<string> groupMembers);
    
    /// <summary>
    /// Delete firewall group
    /// </summary>
    /// <param name="groupId">_id value of the firewall group to delete</param>
    public Task<OperationResult> DeleteFirewallGroup(string groupId);

    /// <summary>
    /// Get all firewall groups
    /// </summary>
    public Task<OperationResultList<FirewallGroupModel>> GetAllFirewallGroup();
}