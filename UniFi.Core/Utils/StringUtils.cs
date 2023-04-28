using System.Text.RegularExpressions;

namespace UniFi.Core.Utils;

public class StringUtils
{
    private static readonly Regex MacRegex = new Regex("^[a-fA-F0-9]{12}$");
    
    public static OperationResult CheckMacAddress(string macAddress)
    {
        if (string.IsNullOrEmpty(macAddress))
            return OperationResult.Fail(Resources.Services_NotEmpty_MacAddress);

        return MacRegex.IsMatch(macAddress.Replace(" ", "").Replace(":", "").Replace("-", "")) 
            ? OperationResult.Success() 
            : OperationResult.Fail(string.Format(Resources.Validate_Error_MacAddress, macAddress));
    }
}