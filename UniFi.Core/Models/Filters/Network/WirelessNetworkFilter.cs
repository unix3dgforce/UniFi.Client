namespace UniFi.Core.Models;

public class WirelessNetworkFilter : BaseFilter
{
    public bool? IsEnabled { get; set; }
    public bool? IsGuest { get; set; }
    public bool? IsSSIDHidden { get; set; }
}