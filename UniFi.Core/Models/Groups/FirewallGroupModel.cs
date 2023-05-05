﻿namespace UniFi.Core.Models;

public class FirewallGroupModel : BaseGroupModel
{
    /// <summary>
    /// Type group
    /// </summary>
    [JsonProperty(PropertyName = "group_type")]
    public FirewallGroupType Type { get; set; }
    
    [JsonProperty(PropertyName = "group_members")]
    public IList<string> Members { get; set; } = new List<string>();
}