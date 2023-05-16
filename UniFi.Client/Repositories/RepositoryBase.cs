using System.ComponentModel.DataAnnotations;
using System.Reflection;
using RestSharp.Extensions;

namespace UniFi.Client.Services;

internal class RepositoryBase
{
    private readonly BaseService _service;
    private readonly string _resource;
    private readonly RepositoryMethodAccess _flagsAccess;

    public RepositoryBase(BaseService service, string resource, RepositoryMethodAccess flagsAccess = RepositoryMethodAccess.All)
    {
        _service = service;
        _resource = resource;
        _flagsAccess = flagsAccess;
    }

    public async Task<OperationResult<T>> Get<T>(T item)
        where T : BaseExtendModel
    {
        if (!_flagsAccess.HasFlag(RepositoryMethodAccess.GetAll) || !_flagsAccess.HasFlag(RepositoryMethodAccess.GetAll))
            return OperationResult<T>.Fail(Resources.Access_Error_Method_Get);
        
        var entity = await CheckExists(item);
        return entity.Result != OperationStatus.Success 
            ? OperationResult<T>.Fail(Resources.Global_Entity_NotFound) 
            : entity;
    }

    public async Task<OperationResultList<T>> GetAll<T>()
        where T : BaseExtendModel
    {
        if (!_flagsAccess.HasFlag(RepositoryMethodAccess.GetAll))
            return OperationResultList<T>.Fail(Resources.Access_Error_Method_GetAll);
        
        return await _service.TryGetAsync<T>(_resource);
    }

    public async Task<OperationResult<T>> Add<T>(T item)
        where T : BaseExtendModel
    {
        if (!_flagsAccess.HasFlag(RepositoryMethodAccess.Add))
            return OperationResult<T>.Fail(Resources.Access_Error_Method_Add);

        if (CheckRequiredIsNullOrEmpty(item))
            return OperationResult<T>.Fail();

        var entity = await CheckExists(item);
        if (entity.Result != OperationStatus.Success)
            return entity;
        
        if (entity.Value != null)
            return OperationResult<T>.Fail(Resources.Global_Entity_AlreadyExists);

        var value = (await _service.TryPostAsync<T>(_resource, item)).Values?.FirstOrDefault();
        if (value == null)
            return OperationResult<T>.Fail(Resources.Api_Error_Request);

        return new OperationResult<T>
        {
            Result = OperationStatus.Success,
            Value = value
        };
    }

    public async Task<OperationResult<T>> Update<T>(T item)
        where T : BaseExtendModel
    {
        if (!_flagsAccess.HasFlag(RepositoryMethodAccess.Update))
            return OperationResult<T>.Fail(Resources.Access_Error_Method_Update);
            
        if (string.IsNullOrEmpty(item.Id))
            return OperationResult<T>.Fail(Resources.Validate_Error_Id);
        
        if (CheckRequiredIsNullOrEmpty(item))
            return OperationResult<T>.Fail();
        
        var entity = await CheckExists(item);
        if (entity.Result != OperationStatus.Success)
            return entity;
        
        if (entity.Value == null)
            return OperationResult<T>.Fail(Resources.Global_Entity_NotFound);

        var value = (await _service.TryPutAsync<T>($"{_resource}/{item.Id}", item)).Values?.FirstOrDefault();
        if (value == null)
            return OperationResult<T>.Fail(Resources.Api_Error_Request);

        return new OperationResult<T>
        {
            Result = OperationStatus.Success,
            Value = value
        };
    }
    
    public async Task<OperationResult> Delete<T>(T item)
        where T : BaseExtendModel
    {
        if (!_flagsAccess.HasFlag(RepositoryMethodAccess.Delete))
            return OperationResult<T>.Fail(Resources.Access_Error_Method_Delete);
        
        if (string.IsNullOrEmpty(item.Id))
            return OperationResult<T>.Fail(Resources.Validate_Error_Id);
        
        var entity = await CheckExists(item);
        if (entity.Result != OperationStatus.Success || entity.Value == null)
            return OperationResult<T>.Fail(Resources.Global_Entity_NotFound);
        
        if (entity.Value.DontAllowDeletion is true)
            return OperationResult<T>.Fail(Resources.Global_Entity_DontAllowDeletion);

        return await _service.TryDeleteAsync($"{_resource}/{item.Id}");
    }
    
    private async Task<OperationResult<T>> CheckExists<T>(T item)
        where T : BaseExtendModel
    {
        var entities = await GetAll<T>();
        if (entities.Result != OperationStatus.Success)
            return new OperationResult<T>
            {
                Errors = entities.Errors,
                Message = entities.Message
            };

        var entity = entities.Values.FirstOrDefault(r =>
            typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes(typeof(CheckExistAttribute), true).Any())
                .Any(p => p.GetValue(r).Equals(p.GetValue(item))));

        return new OperationResult<T>
        {
            Result = OperationStatus.Success,
            Value = entity
        };
    }

    private bool CheckRequiredIsNullOrEmpty<T>(T item)
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetAttribute<RequiredAttribute>() != null && p.PropertyType == typeof(string))
            .Select(p => string.IsNullOrEmpty((string?)p.GetValue(item)))
            .FirstOrDefault();
    }
}