using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UniFi.Core.Models;

public class AuthorizeGuestModel: BaseModel
{
    /// <summary>
    /// Client Mac Address
    /// </summary>
    [Required, JsonProperty(PropertyName = "mac")]
    public string MacAddress { get; set; }
    
    /// <summary>
    /// Minutes (from now) until authorization expires. Default 144000 minutes = 24 hours
    /// </summary>
    [JsonProperty(PropertyName = "minutes")]
    public int Duration { get; init; } = 144000;

    [JsonProperty(PropertyName = "cmd")] 
    public string Action { get; init; } = "authorize-guest";

    /// <summary>
    /// Upload speed limit in kbps
    /// </summary>
    [JsonProperty(PropertyName = "up")]
    public int? UploadLimit { get; set; }
    
    /// <summary>
    /// Download speed limit in kbps
    /// </summary>
    [JsonProperty(PropertyName = "down")]
    public int? DownloadLimit { get; set; }
    
    /// <summary>
    /// Data transfer limit in MB
    /// </summary>
    [JsonProperty(PropertyName = "bytes")]
    public int? TrafficLimit { get; set; }
    
    [JsonProperty(PropertyName = "ap_mac")]
    public string? ApMacAddress { get; set; }

}