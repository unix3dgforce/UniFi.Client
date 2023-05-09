namespace UniFi.Core.Services;

public interface IRadiusProfileService : IService
{
    /*
     * {
  "attr_no_delete": false,
  "attr_hidden_id": "",
  "name": "TEST",
  "use_usg_auth_server": false,
  "auth_servers": [
    {
      "ip": "192.168.200.1",
      "port": 1812,
      "x_secret": "TEST"
    }
  ],
  "acct_servers": [
    {
      "ip": "192.168.202.1",
      "port": 1813,
      "x_secret": "testt"
    }
  ],
  "vlan_enabled": true,
  "vlan_wlan_mode": "optional",
  "accounting_enabled": true,
  "interim_update_enabled": true,
  "interim_update_interval": "3600"
}
     */
    /// <summary>
    /// Create radius profile 
    /// </summary>
    /// <param name="item">Radius profile model</param>
    public Task<OperationResult<RadiusProfileModel>> CreateRadiusProfile(RadiusProfileModel item);

    /*
     * {
  "attr_no_delete": false,
  "attr_hidden_id": "",
  "name": "TEST",
  "use_usg_auth_server": false,
  "auth_servers": [
    {
      "ip": "192.168.200.1",
      "port": 1812,
      "x_secret": "TEST"
    }
  ],
  "acct_servers": [
    {
      "ip": "192.168.202.1",
      "port": 1813,
      "x_secret": "testt"
    }
  ],
  "vlan_enabled": false,
  "vlan_wlan_mode": "disabled",
  "accounting_enabled": true,
  "interim_update_enabled": true,
  "interim_update_interval": "3600",
  "site_id": "63f4dcfdb8f7190897a40e67",
  "_id": "6455d3942bf43e0d928663d7"
}
     */
    /// <summary>
    /// Update radius profile 
    /// </summary>
    /// <param name="item">Radius profile model</param>
    public Task<OperationResult<RadiusProfileModel>> UpdateRadiusProfile(RadiusProfileModel item);

    /// <summary>
    /// Delete radius profile 
    /// </summary>
    /// <param name="item">Radius profile model</param>
    public Task<OperationResult> DeleteRadiusProfile(RadiusProfileModel item);
    
    /// <summary>
    /// Get all radius profiles
    /// </summary>
    public Task<OperationResultList<RadiusProfileModel>> GetAllRadiusProfiles();
}