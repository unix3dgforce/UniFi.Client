﻿namespace UniFi.Core.Services;

public interface IBackupService : IService
{
    /// <summary>
    /// Generate a backup/export of the current site
    /// </summary>
    /// <returns></returns>
    public Task<OperationResult> BackupSite();
    
    /// <summary>
    /// Generate a backup
    /// </summary>
    /// <returns></returns>
    public Task<OperationResult<BackupDownloadModel>> BackupFull();
    
    /// <summary>
    /// Delete backup
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public Task<OperationResult> DeleteBackup(string filename);
    
    /// <summary>
    /// Get list of autobackup files 
    /// </summary>
    /// <returns></returns>
    public Task<OperationResultList<BackupModel>> GetAllBackups();
}