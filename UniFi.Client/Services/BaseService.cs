﻿namespace UniFi.Client.Services;

public abstract class BaseService : IService
{
    private const string Prefix = "proxy/network/";
    private readonly RestClient _restClient;
    private readonly IConfigService _configService;

    protected string SiteId => _configService.AppConfig.Controller?.SiteId ?? "default";

    protected BaseService(RestClient restClient, IConfigService configService)
    {
        _restClient = restClient;
        _configService = configService;
    }

    private async Task<OperationResult> Execute(
        Func<string, object, CancellationToken, Task<OperationResult>> func,
        string resource,
        object body = null,
        CancellationToken cancellationToken = default)
    {
        var result = await func(resource, body, cancellationToken);
        if (result.Result == OperationStatus.Success)
            return result;
        
        return await func($"{Prefix}{resource}", body, cancellationToken);
    }

    private async Task<OperationResultList<T>> Execute<T>(
        Func<string, object, CancellationToken, Task<OperationResultList<T>>> func,
        string resource,
        object body = null,
        CancellationToken cancellationToken = default)
        where T : BaseModel
    {
        var result = await func(resource, body, cancellationToken);
        if (result.Result == OperationStatus.Success)
            return result;

        return await func($"{Prefix}{resource}", body, cancellationToken);
    }

    protected internal async Task<OperationResultList<T>> TryGetAsync<T>(string resource)
        where T : BaseModel
    {
        return await Execute(_restClient.GetAsync<T>, resource);
    }

    protected internal async Task<OperationResult> TryPostAsync(string resource, object body = null)
    {
        return await Execute(_restClient.PostAsync, resource, body);
    }

    protected internal async Task<OperationResultList<T>> TryPostAsync<T>(string resource, object body = null)
        where T : BaseModel
    {
        return await Execute(_restClient.PostAsync<T>, resource, body);
    }
    
    protected internal async Task<OperationResult> TryPutAsync(string resource, object body = null)
    {
        return await Execute(_restClient.PutAsync, resource, body);
    }
    
    protected internal async Task<OperationResultList<T>> TryPutAsync<T>(string resource, object body = null)
        where T : BaseModel
    {
        return await Execute(_restClient.PutAsync<T>, resource, body);
    }
    
    protected internal async Task<OperationResult> TryDeleteAsync(string resource, object body = null)
    {
        return await Execute(_restClient.DeleteAsync, resource, body);
    }
    
    protected internal async Task<OperationResultList<T>> TryDeleteAsync<T>(string resource, object body = null)
        where T : BaseModel
    {
        return await Execute(_restClient.DeleteAsync<T>, resource, body);
    }

    protected async Task<OperationResult<T>> CheckExists<T>(Func<Task<OperationResultList<T>>> funcGetAllGroup, string value, bool isValueId = false)
        where T : BaseExtendModel
    {
        var groups = await funcGetAllGroup();
        if (groups.Result != OperationStatus.Success)
            return OperationResult<T>.Fail();

        return new OperationResult<T>
        {
            Result = OperationStatus.Success,
            // Value = groups.Values.FirstOrDefault(g => isValueId ? g.Id == value : g.Name == value, null)
            Value = null
        };
    }
}
