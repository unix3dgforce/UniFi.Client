namespace UniFi.Core.Models;

public class MetaModel
{
    /// <summary>
    /// The result code indicating the successfulness of the request
    /// </summary>
    
    [JsonProperty(PropertyName = "uuid")]
    public Guid Id { get; set; }
    
    [JsonProperty(PropertyName = "up")]
    public bool ServerRun { get; set; }
    
    [JsonProperty(PropertyName = "server_version")]
    public string ServerVersion { get; set; }
    
    [JsonProperty(PropertyName = "rc", Required = Required.Always)]
    public ResultCodeState ResultCode { get; set; }
    
}