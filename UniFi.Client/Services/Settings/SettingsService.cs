namespace UniFi.Client.Services;

public class SettingsService : BaseService, ISettingsService 
{
    private RepositoryBase RepositoryNTP { get; }
        
    public SettingsService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        RepositoryNTP = new RepositoryBase(this, $"api/s/{SiteId}/rest/setting/ntp", RepositoryMethodAccess.Get | RepositoryMethodAccess.GetAll | RepositoryMethodAccess.Update);
        
    }

    public async Task<OperationResult<NTPModel>> GetNTPSettings()
    {
        var entity = await RepositoryNTP.GetAll<NTPModel>();
        if (entity.Result != OperationStatus.Success || !entity.Values.Any())
            return OperationResult<NTPModel>.Fail();

        return new OperationResult<NTPModel>
        {
            Result = OperationStatus.Success,
            Value = entity.Values.First()
        };
    }

    public Task<OperationResult<NTPModel>> EditNTPSettings(NTPModel item)
    {
        return RepositoryNTP.Update(item);
    }
}