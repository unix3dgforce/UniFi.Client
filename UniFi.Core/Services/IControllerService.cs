namespace UniFi.Core.Services;

public interface IControllerService : IService
{
    /// <summary>
    /// Create a site
    /// </summary>
    /// <param name="description">The long name for the new site</param>
    public Task<OperationResult> CreateSite(string description);
    
    /// <summary>
    /// Change the current site's name
    /// NOTES: immediately after being changed, the site is available in the output of the list_sites() function
    /// </summary>
    /// <param name="siteName"></param>
    public Task<OperationResult> EditSite(string siteName);

    /// <summary>
    /// Delete site 
    /// </summary>
    /// <param name="siteId">_id value of the site to delete</param>
    public Task<OperationResult> DeleteSite(string siteId);

    /// <summary>
    /// Get all sites 
    /// </summary>
    public Task<OperationResultList<SiteModel>> GetAllSites();
}