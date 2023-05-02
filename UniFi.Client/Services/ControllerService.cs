namespace UniFi.Client.Services;

public class ControllerService : BaseService, IControllerService
{
    public ControllerService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }
    
    public async Task<OperationResultList<SiteModel>> GetSites()
    {
        return await TryGetAsync<SiteModel>("api/self/sites");
    }
}