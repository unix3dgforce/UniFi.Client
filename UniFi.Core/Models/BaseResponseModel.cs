namespace UniFi.Core.Models;

public class BaseResponseModel<T>
    where T : BaseModel
{
    /// <summary>
    /// Data resulting from a request towards the UniFi Controller
    /// </summary>
    public IList<T> Data { get; set; } = new List<T>();
    
    public MetaModel Meta { get; set; }
}