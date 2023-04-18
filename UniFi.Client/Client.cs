using System.Net;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace UniFi.Client;

public class Client
{
    private readonly RestClient _client;
    private readonly IConfigService _config;

    public Client(IConfigService config)
    {
        _config = config;
        _client = new RestClient("host", configureSerialization: s => s.UseNewtonsoftJson());
    }

    public async Task<RestResponse> ExecuteAsync(string resource, Method method,  object body = null)
    {
        
    }

    public async Task<OperationResult<T>> ExecuteAsync<T>(string resource, Method method,  object body = null)
        where T : OperationResult
    {
        var accepted = new[]
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.Accepted,
            HttpStatusCode.NonAuthoritativeInformation,
            HttpStatusCode.NoContent,
            HttpStatusCode.ResetContent,
            HttpStatusCode.PartialContent,
            HttpStatusCode.MultiStatus,
            HttpStatusCode.AlreadyReported,
            HttpStatusCode.IMUsed
        };
    }

    public async Task<OperationResult<T>> Get<T>(string resource, object body = null)
        where T : 
    {
        return ExecuteAsync<T>(resource, Method.Get, body);
    }

    public async Task<OperationResult<T>> Post<T>(string resource, object body = null)
    {
        var response = await ExecuteAsync<OperationResult<T>>(resource, Method.Post, body);

    }
    
    public async Task<OperationResult<T>> Put<T>(string resource, object body = null)
    {
        var response = await ExecuteAsync<OperationResult<T>>(resource, Method.Put, body);

    }
    
    public async Task<OperationResult<T>> Delete<T>(string resource, object body = null)
    {
        var response = await ExecuteAsync<OperationResult<T>>(resource, Method.Delete, body);

    }

    private static RestRequest CreateRequest(string resource, Method method, object body = null)
    {
        if (body != null)
            
    }
 
}