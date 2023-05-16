namespace UniFi.Core.Services;

public interface INetworkConfigService : IService
{
    public Task<OperationResultList<BaseExtendModel>> GetAllNetworkConfig();
}