namespace UniFi.Core.Services;

public interface IAccessPointService : IService
{
    /// <summary>
    /// Toggle flashing LED of an access point for locating purposes
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    /// <param name="state">true enables flashing LED, false disables flashing LED</param>
    public Task<OperationResult> LocateAccessPoint(string macAddress, bool state);

    /// <summary>
    /// Rename access point
    /// </summary>
    /// <param name="accessPointId">ID (_id) of the access point to rename, which can be obtained from the device list</param>
    /// <param name="name">New name to assign to the access point</param>
    public Task<OperationResult> RenameAccessPoint(string accessPointId, string name);

    /// <summary>
    /// Disable/Enable an access point 
    /// </summary>
    /// <param name="accessPointId">ID (_id) of the access point, which can be obtained from the device list</param>
    /// <param name="state"></param>
    public Task<OperationResult> DisableAccessPoint(string accessPointId, bool state);
}