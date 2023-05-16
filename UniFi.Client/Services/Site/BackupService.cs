namespace UniFi.Client.Services;

public class BackupService : BaseService, IBackupService
{
    private readonly IConfigService _configService;

    private RepositoryBase Repository { get; }

    public BackupService(RestClient restClient, IConfigService configService) : base(restClient, configService)
    {
        _configService = configService;
        Repository = new RepositoryBase(this, $"api/s/{SiteId}/cmd/backup", RepositoryMethodAccess.GetAll);
    }

    public async Task<OperationResult> BackupSite()
    {
        return await GenerateBackup("export-site");
    }

    public async Task<OperationResult<BackupDownloadModel>> BackupFull()
    {
        return await GenerateBackup("backup");
    }

    public async Task<OperationResult> DeleteBackup(string filename)
    {
        if (string.IsNullOrEmpty(filename))
            return OperationResult.Fail(Resources.Backup_Info_NotEmpty_Filename);

        var backups = await GetAllBackups();
        if (backups.Result != OperationStatus.Success)
            return backups;

        if (backups.Values.FirstOrDefault(b => b?.Filename == filename, null) == null)
            return OperationResult.Fail(string.Format(Resources.Backup_Info_NotFound_Filename, filename));

        return await TryPostAsync($"api/s/{SiteId}/cmd/backup", new { Filename = filename, Cmd = "delete-backup"});
    }

    public async Task<OperationResultList<BackupModel>> GetAllBackups()
    {
        return await TryPostAsync<BackupModel>($"api/s/{SiteId}/cmd/backup", new { Cmd = "list-backups" });
    }
    
    private async Task<OperationResult<BackupDownloadModel>> GenerateBackup(string command)
    {
        var response = await TryPostAsync<BackupDownloadModel>($"api/s/{SiteId}/cmd/backup", new { Cmd = command });
        if (response.Result != OperationStatus.Success)
            return OperationResult<BackupDownloadModel>.Fail(Resources.Backup_Error_Generation);
        
        var backup = response.Values.FirstOrDefault(b => !string.IsNullOrEmpty(b.DownloadUrl), null);
        if (backup == null)
            return OperationResult<BackupDownloadModel>.Fail(Resources.Backup_Error_Generation);

        return new OperationResult<BackupDownloadModel>
        {
            Result = OperationStatus.Success,
            Value = new BackupDownloadModel
            {
                DownloadUrl = $"https://{_configService.AppConfig.Endpoint.Host}:{_configService.AppConfig.Endpoint.Port}{backup.DownloadUrl}"
            }
        };
    }
}