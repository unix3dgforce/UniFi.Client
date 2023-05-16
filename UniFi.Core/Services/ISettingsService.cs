namespace UniFi.Core.Services;

public interface ISettingsService : IService
{
    /// <summary>
    /// Get current NTP settings 
    /// </summary>
    public Task<OperationResult<NTPModel>> GetNTPSettings();
    
    /// <summary>
    /// Update NTP settings
    /// </summary>
    /// <param name="item"></param>
    public Task<OperationResult<NTPModel>> EditNTPSettings(NTPModel item);
}