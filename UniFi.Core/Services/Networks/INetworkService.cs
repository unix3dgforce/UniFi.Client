namespace UniFi.Core.Services;

public interface INetworkService : IService
{
    /// <summary>
    /// Get all networks 
    /// </summary>
    public Task<OperationResultList<NetworkModel>> GetWiredNetwork(WiredNetworkFilter filter = null);

    /// <summary>
    /// Get all wireless network 
    /// </summary>
    public Task<OperationResultList<WirelessNetworkModel>> GetWirelessNetwork(WirelessNetworkFilter filter = null);
}