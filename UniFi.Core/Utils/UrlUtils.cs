namespace UniFi.Core.Utils;

public class UrlUtils
{
    public static OperationResult IsValidUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
            return OperationResult.Fail();

        return Uri.TryCreate(url, UriKind.Absolute, out var result) 
               && (result.Scheme == Uri.UriSchemeHttp ||
                   result.Scheme == Uri.UriSchemeHttps ||
                   result.Scheme == Uri.UriSchemeFtp ||
                   result.Scheme == Uri.UriSchemeFtps)
            ? OperationResult.Success()
            : OperationResult.Fail();
    }
}