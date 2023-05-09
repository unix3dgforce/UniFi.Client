namespace UniFi.Core.Models;

public class BaseExtendModel : BaseModel
{
    /// <summary>
    /// Unique identifier of the site
    /// </summary>
    [CheckExist]
    [JsonProperty(PropertyName = "_id")] 
    public string Id { get; set; }
    
    /// <summary>
    /// Unique site id 
    /// </summary>
    [JsonProperty(PropertyName = "site_id")] 
    public string SiteId { get; set; }
    
    /// <summary>
    /// Boolean indicating if deletion of this site is being disallowed
    /// </summary>
    [JsonProperty(PropertyName = "attr_no_delete")]
    public bool? DontAllowDeletion { get; set; }
}