namespace UniFi.Client.Services;

public class ClientService : BaseService, IClientService
{
    private RepositoryBase Repository { get; }

    public ClientService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/stat/alluser", RepositoryMethodAccess.GetAll);
    }
    
    public async Task<OperationResult> AuthorizeGuest(string macAddress)
    {
        return await AuthorizeGuest(new AuthorizeGuestModel { MacAddress = macAddress });

    }

    public async Task<OperationResult> AuthorizeGuest(AuthorizeGuestModel authorizeGuestModel)
    {
        if (authorizeGuestModel.ApMacAddress != null && StringUtils.CheckMacAddress(authorizeGuestModel.ApMacAddress).Result != OperationStatus.Success)
            authorizeGuestModel.ApMacAddress = null;
        
        var result = StringUtils.CheckMacAddress(authorizeGuestModel.MacAddress);

        return result.Result != OperationStatus.Success
            ? result
            : await TryPostAsync<ClientModel>($"api/s/{SiteId}/cmd/stamgr", authorizeGuestModel);
    }


    public async Task<OperationResult> UnauthorizeGuest(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success 
            ? result 
            : await TryPostAsync<ClientModel>($"api/s/{SiteId}/cmd/stamgr", new {Mac = macAddress, Cmd = "unauthorize-guest"});
    }
    
    public async Task<OperationResult> BlockClient(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success 
            ? result 
            : await TryPostAsync<ClientModel>($"api/s/{SiteId}/cmd/stamgr", new {Mac = macAddress, Cmd = "block-sta"});
    }

    public async Task<OperationResult> UnblockClient(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success 
            ? result 
            : await TryPostAsync<ClientModel>($"api/s/{SiteId}/cmd/stamgr", new {Mac = macAddress, Cmd = "unblock-sta"});
    }

    public async Task<OperationResult> ReconnectClient(string macAddress)
    {
        var result = StringUtils.CheckMacAddress(macAddress);

        return result.Result != OperationStatus.Success 
            ? result 
            : await TryPostAsync($"api/s/{SiteId}/cmd/stamgr", new { Mac = macAddress, Cmd = "kick-sta"});
    }

    public async Task<OperationResult<ClientModel>> RenameClient(string userId, string name)
    {
        throw new NotImplementedException();
    }

    public async Task<OperationResultList<ClientModel>> GetAllActiveClients()
    {
        return await TryGetAsync<ClientModel>($"api/s/{SiteId}/stat/sta");
    }
    
    public async Task<OperationResultList<ClientModel>> GetAllClients()
    {
        return await Repository.GetAll<ClientModel>();
    }
}