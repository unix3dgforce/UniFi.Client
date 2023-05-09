using System.Reflection;

namespace UniFi.Client.Services;

public class RepositoryBase
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
        if (_flagsAccess is not (RepositoryMethodAccess.Get or RepositoryMethodAccess.All))
            return OperationResult<T>.Fail(Resources.Access_Error_Method_Get);

        // var model = (await GetAll<T>()).Values?.FirstOrDefault(r => type == TypeOfValue.Id ? r.Id == item.Id : r.Name == item.Name, null);
        // if (model == null)
        //     return OperationResult<T>.Fail();

        return new OperationResult<T>
        {
            Result = OperationStatus.Success,
            // Value = model
            Value = null
        };
    }

    public async Task<OperationResultList<T>> GetAll<T>()
        where T : BaseExtendModel
    {
        if (_flagsAccess is not (RepositoryMethodAccess.GetAll or RepositoryMethodAccess.All))
            return OperationResultList<T>.Fail(Resources.Access_Error_Method_GetAll);
        
        return await _service.TryGetAsync<T>(_resource);
    }

    public async Task<OperationResult<T>> Add<T>(T item)
        where T : BaseExtendModel
    {
        if (_flagsAccess is not (RepositoryMethodAccess.Add or RepositoryMethodAccess.All))
            return OperationResult<T>.Fail(Resources.Access_Error_Method_Add);

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
        if (_flagsAccess is not (RepositoryMethodAccess.Update or RepositoryMethodAccess.All))
            return OperationResult<T>.Fail(Resources.Access_Error_Method_Update);
        
        if (string.IsNullOrEmpty(item.Id))
            return OperationResult<T>.Fail(Resources.Validate_Error_Id);
        
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
        if (_flagsAccess is not (RepositoryMethodAccess.Delete or RepositoryMethodAccess.All))
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

        var validateProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetCustomAttributes(typeof(CheckExistAttribute), true).Any());

        var entity = entities.Values.FirstOrDefault(r => validateProperties.Any(p => p.GetValue(r).Equals(p.GetValue(item))));

        return new OperationResult<T>
        {
            Result = OperationStatus.Success,
            Value = entity
        };
    }
}