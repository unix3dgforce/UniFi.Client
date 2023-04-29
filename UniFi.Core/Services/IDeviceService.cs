namespace UniFi.Core.Services;

public interface IDeviceService : IService
{
    /// <summary>
    /// Adopt a device to the selected site
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    public Task<OperationResult> AdoptDevice(string macAddress);
    
    /// <summary>
    /// Force provision of a device
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    public Task<OperationResult> ForceProvision(string macAddress);

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
    /// Delete a device from the current site
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    public Task<OperationResult> DeleteDevice(string macAddress);

    /// <summary>
    /// Upgrade a device to the latest firmware
    /// NOTES: updates the device to the latest STABLE firmware known to the controller
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    public Task<OperationResult> UpgradeDevice(string macAddress);
    
    /// <summary>
    /// Upgrade a device to a specific firmware file
    /// NOTES:
    ///     - updates the device to the firmware file at the given URL
    ///     - please take great care to select a valid firmware file for the device!
    /// </summary>
    /// <param name="macAddress">Device MAC address</param>
    /// <param name="firmwareUrl">URL for the firmware file to upgrade the device to</param>
    /// <returns></returns>
    public Task<OperationResult> UpgradeDeviceExternal(string macAddress, string firmwareUrl);
}