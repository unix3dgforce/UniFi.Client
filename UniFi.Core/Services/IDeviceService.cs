namespace UniFi.Core.Services;

public interface IDeviceService : IService
{
    /// <summary>
    /// Adopt a device to the selected site
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    public Task<OperationResult> AdoptDevice(string macAddress);

    /// <summary>
    /// Reboot a device
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    /// <param name="rebootType">'soft' or 'hard', defaults to soft.
    /// Soft can be used for all devices, requests a plain restart of that device
    /// Hard is special for PoE switches and besides the restart also requests a power cycle on all PoE capable ports.
    /// Keep in mind that a 'hard' reboot does *NOT* trigger a factory-reset.</param>
    public Task<OperationResult> RestartDevice(string macAddress, RebootType rebootType = RebootType.Soft);

    /// <summary>
    /// Force provision of a device
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    public Task<OperationResult> ForceProvision(string macAddress);
}