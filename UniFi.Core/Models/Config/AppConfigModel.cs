namespace UniFi.Core.Models;

public class AppConfigModel
{
    public HostConfigModel Endpoint { get; init; }
    public CredentialConfigModel Credential { get; init; }
    public ControllerPreConfigModel Controller { get; init; }
}