namespace UniFi.Client.Services;

public class SiteService : BaseService, ISiteService
{
    public SiteService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }

    public Task<OperationResult> CreateSite(string description)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> EditSite(string siteName)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> DeleteSite(string siteId)
    {
        throw new NotImplementedException();
    }

    public async Task<OperationResultList<SiteModel>> GetAllSites()
    {
        return await TryGetAsync<SiteModel>("api/self/sites");
    }
}