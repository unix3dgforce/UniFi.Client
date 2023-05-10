namespace UniFi.Core.Models;

public class UserBandwidthProfileModel : BaseExtendModel
{
    /// <summary>
    /// Name group
    /// </summary>
    [CheckExist]
    public string Name { get; set; }
    
    /// <summary>
    /// Internal identifier of the site
    /// </summary>
    [JsonProperty(PropertyName = "attr_hidden_id")]
    public string HiddenId { get; set; }

    /// <summary>
    /// Boolean indicating if deletion of this site is being disallowed
    /// </summary>
    [JsonProperty(PropertyName = "attr_no_delete")]
    public bool? DontAllowDeletion { get; set; }

    /// <summary>
    /// QOS: download speed in kbps limit for a group of users
    /// NOTES: -1 (default) unlimited  
    /// </summary>
    [JsonProperty(PropertyName = "qos_rate_max_down")]
    public int QosDownloadMaxLimit { get; set; } = -1;
    
    /// <summary>
    /// QOS: upload speed in kbps limit for a group of users
    /// NOTES: -1 (default) unlimited  
    /// </summary>
    [JsonProperty(PropertyName = "qos_rate_max_up")]

    public int QosUploadMaxLimit { get; set; } = -1;

}