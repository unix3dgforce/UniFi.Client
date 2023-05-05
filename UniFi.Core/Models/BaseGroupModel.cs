namespace UniFi.Core.Models;

public class BaseGroupModel : BaseModel
{
    /// <summary>
    /// Unique identifier of the site
    /// </summary>
    [JsonProperty(PropertyName = "_id")] 
    public string Id { get; set; }
    
    /// <summary>
    /// Unique site id 
    /// </summary>
    [JsonProperty(PropertyName = "site_id")] 
    public string SiteId { get; set; }
    
    /// <summary>
    /// Name firewall group
    /// </summary>
    public string Name { get; set; }
}