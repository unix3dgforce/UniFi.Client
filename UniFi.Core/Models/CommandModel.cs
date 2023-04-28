using System.Dynamic;

namespace UniFi.Core.Models;

public class CommandModel
{
    [JsonProperty(PropertyName = "mac")]
    public string Mac { get; set; }

    [JsonProperty(PropertyName = "cmd")] 
    public string RunCommand { get; set; }
}

// public class CommandModel : DynamicObject
// {
//     private Dictionary<string, object> memebers = new Dictionary<string, object>();
//
//     public override bool TrySetMember(SetMemberBinder binder, object? value)
//     {
//         if (value == null)
//             return false;
//
//         memebers[binder.Name] = value;
//         return true;
//     }
//
//     public override bool TryGetMember(GetMemberBinder binder, out object? result)
//     {
//         if (!memebers.ContainsKey(binder.Name))
//         {
//             result = null;
//             return false;
//         }
//
//         result = memebers[binder.Name];
//         return true;
//     }
// }