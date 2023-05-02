using UniFi.Core.Utils;

namespace UniFi.Core.Models;

public class BackupModel : BaseModel
{
    public string ControllerName { get; set; }
    
    public string Filename { get; set; }
    
    public string Version { get; set; }

    [JsonProperty(PropertyName = "time")]
    public long Timestamp { get; set; }
    
    public string Format { get; set; }
    
    public int Days { get; set; }
    
    public long Size { get; set; }
    
    public DateTime Date => DateTime.UnixEpoch.AddMilliseconds(Timestamp);
}