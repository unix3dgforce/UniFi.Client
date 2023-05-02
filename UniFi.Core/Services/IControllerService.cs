namespace UniFi.Core.Services;

public interface IControllerService : IService
{
    public Task<OperationResultList<SiteModel>> GetSites();
}