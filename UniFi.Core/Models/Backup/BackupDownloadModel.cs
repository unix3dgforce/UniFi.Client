namespace UniFi.Core.Models;

public class BackupDownloadModel : BaseModel
{
    [JsonProperty(PropertyName = "url")]
    public string DownloadUrl { get; set; }
}