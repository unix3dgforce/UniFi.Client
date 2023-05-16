namespace UniFi.Client.Services;

public class RadiusProfileService : BaseService, IRadiusProfileService
{
    private RepositoryBase Repository { get; }
    
    public RadiusProfileService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/rest/radiusprofile");
    }

    public async Task<OperationResult<RadiusProfileModel>> CreateRadiusProfile(RadiusProfileModel item)
    {
        return await Repository.Add(item);
    }

    public async Task<OperationResult<RadiusProfileModel>> EditRadiusProfile(RadiusProfileModel item)
    {
        return await Repository.Update(item);
    }

    public async Task<OperationResult> DeleteRadiusProfile(RadiusProfileModel item)
    {
        return await Repository.Delete(item);
    }

    public async Task<OperationResultList<RadiusProfileModel>> GetAllRadiusProfiles()
    {
        return await Repository.GetAll<RadiusProfileModel>();
    }
}