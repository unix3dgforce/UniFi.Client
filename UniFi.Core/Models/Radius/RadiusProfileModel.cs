namespace UniFi.Core.Models;

public class RadiusProfileModel : BaseExtendModel
{
    /// <summary>
    /// Name group
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Internal identifier of the site
    /// </summary>
    [JsonProperty(PropertyName = "attr_hidden_id")]
    public string HiddenId { get; set; }
    
    /// <summary>
    /// Boolean indicating if editable of this site is being disallowed
    /// </summary>
    [JsonProperty(PropertyName = "attr_no_edit")]
    public bool? DontAllowEditable { get; set; }

    /// <summary>
    /// Boolean indicating if deletion of this site is being disallowed
    /// </summary>
    [JsonProperty(PropertyName = "attr_no_delete")]
    public bool? DontAllowDeletion { get; set; }

    [JsonProperty(PropertyName = "use_usg_auth_server")]
    public bool UseUsgAuthServer { get; set; }

    public IList<RadiusCredentialModel> AuthServers { get; set; } = new List<RadiusCredentialModel>();
    public IList<RadiusCredentialModel> AcctServers { get; set; } = new List<RadiusCredentialModel>();
    
    [JsonProperty(PropertyName = "vlan_enabled")]
    public bool IsVlanEnabled { get; set; }
    
    [JsonProperty(PropertyName = "vlan_wlan_mode")]
    public VlanWlanModeEnum WlanMode { get; set; }
    
    [JsonProperty(PropertyName = "accounting_enabled")]
    public bool IsAccountingEnabled { get; set; }
    
    [JsonProperty(PropertyName = "interim_update_enabled")]
    public bool IsInterimUpdateEnable { get; set; }

    public string InterimUpdateInterval { get; set; }
}