using UniFi.Core;

namespace UniFi.Client.Services;

public class BackupService : BaseService, IBackupService
{
    public BackupService(RestClient restClient, IConfigService configService) : base(restClient, configService) { }

    public Task<OperationResult> BackupSite()
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> BackupFull()
    {
        throw new NotImplementedException();
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

}