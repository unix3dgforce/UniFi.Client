namespace UniFi.Core.Services;

public interface IClientService : IService
{
    /// <summary>
    /// Authorizes a guest to access the network
    /// </summary>
    /// <param name="macAddress">The MAC address of the client to provide access to the network</param>
    public Task<OperationResult> AuthorizeGuest(string macAddress);
    
    /// <summary>
    /// Authorizes a guest to access the network
    /// </summary>
    /// <param name="authorizeGuestModel">User authorization model</param>
    public Task<OperationResult> AuthorizeGuest(AuthorizeGuestModel authorizeGuestModel);

    /// <summary>
    /// Unauthorizes a guest to access the network
    /// </summary>
    /// <param name="macAddress">The MAC address of the client to revoke its access from the network</param>
    public Task<OperationResult> UnauthorizeGuest(string macAddress);
    
    /// <summary>
    /// Blocks a client from accessing the network
    /// </summary>
    /// <param name="macAddress">The MAC address of the client to block from getting access to the network</param>
    public Task<OperationResult> BlockClient(string macAddress);
    
    /// <summary>
    /// Unblocks a client from accessing the network
    /// </summary>
    /// <param name="macAddress">The MAC address of the client to unblock from getting access to the network</param>
    public Task<OperationResult> UnblockClient(string macAddress);
    
    /// <summary>
    /// Reconnects the provided client
    /// </summary>
    /// <param name="macAddress">The MAC address of client to reconnect</param>
    /// <returns>True if the reconnect was successful or False if it failed</returns>
    public Task<OperationResult> ReconnectClient(string macAddress);

    /// <summary>
    /// Rename Client
    /// </summary>
    /// <param name="userId">Client's User Id for client to be renamed</param>
    /// <param name="name">New name</param>
    public Task<OperationResult<ClientModel>> RenameClient(string userId, string name);

    /// <summary>
    /// Gets the currently connected clients
    /// </summary>
    /// <returns>List with connected clients</returns>
    public Task<OperationResultList<ClientModel>> GetAllActiveClients();

    /// <summary>
    /// Gets all clients known to UniFi. This contains both clients currently connected as well as clients that were connected in the past.
    /// </summary>
    /// <returns>List with all known clients</returns>
    public Task<OperationResultList<ClientModel>> GetAllClients();
}