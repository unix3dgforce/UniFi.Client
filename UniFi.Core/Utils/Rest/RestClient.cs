using System.Net;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using UniFi.Core.Services;

namespace UniFi.Core.Utils;

public class RestClient
{
    private readonly RestSharp.RestClient _client;

    private readonly List<HttpStatusCode> _accepted = new List<HttpStatusCode>()
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

    public RestClient(IConfigService configService)
    {
        _client = new RestSharp.RestClient("host", configureSerialization: s => s.UseNewtonsoftJson());
    }

    public async Task<OperationResult<T>> GetAsync<T>(string resource, object body = null, string csrf_token = null)
        where T : ModelBase
    {
        
    }
    
    public async Task<OperationResult<T>> PostAsync<T>(string resource, object body = null, string csrf_token = null)
        where T : ModelBase
    {
        
    }
    
    public async Task<OperationResult<T>> PutAsync<T>(string resource, object body = null, string csrf_token = null)
        where T : ModelBase
    {
        
    }
    
    public async Task<OperationResult<T>> DeleteAsync<T>(string resource, object body = null, string csrf_token = null)
        where T : ModelBase
    {
        
    }
    
    public async Task<OperationResult> ExecuteAsync(string resource, Method method, object body = null, string csrf_token = null)
    {
        
    }

    public async Task<OperationResult<T>> ExecuteAsync<T>(string resource, Method method, object body = null, string csrf_token = null)
        where T : ModelBase
    {
        
    }

    private static RestRequest CreateRequest(string resource, Method method, object body = null, string csrf_token = null)
    {
        // TODO:  `BASE_URL` + resource
        var request = new RestRequest(resource, method) { RequestFormat = DataFormat.Json };

        if (body != null)
            request.AddJsonBody(body);

        if (csrf_token != null)
            request.AddOrUpdateHeader("X-Csrf-Token", csrf_token);

        return request;
    }
}