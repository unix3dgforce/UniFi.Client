using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using UniFi.Core.Services;

namespace UniFi.Core.Utils;

public class RestClient
{
    private readonly RestSharp.RestClient _client;
    private readonly ICacheService _cache;
    private readonly IConfigService _config;
    private readonly string _baseUrl;

    public RestClient(IConfigService configService, ICacheService cacheService)
    {
        _cache = cacheService;
        _config = configService;
        _baseUrl = $"https://{_config.AppConfig.Endpoint.Host}:{_config.AppConfig.Endpoint.Port}";

        var options = new RestSharp.RestClientOptions(_baseUrl)
        {
            RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
        };

        _client = new RestSharp.RestClient(
            options,
            configureSerialization: s => s.UseNewtonsoftJson(
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() },
                    DefaultValueHandling = DefaultValueHandling.Include,
                    TypeNameHandling = TypeNameHandling.None,
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.None,
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                })
        );
    }

    public async Task<OperationResult> GetAsync(string resource, object body = null, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(resource, Method.Get, body, cancellationToken);
    }

    public async Task<OperationResultList<T>> GetAsync<T>(string resource, object body = null, CancellationToken cancellationToken = default)
        where T : BaseModel
    {
        return await ExecuteAsync<T>(resource, Method.Get, body, cancellationToken);
    }

    public async Task<OperationResult> PostAsync(string resource, object body = null, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(resource, Method.Post, body, cancellationToken);
    }

    public async Task<OperationResultList<T>> PostAsync<T>(string resource, object body = null, CancellationToken cancellationToken = default)
        where T : BaseModel
    {
        return await ExecuteAsync<T>(resource, Method.Post, body, cancellationToken);
    }

    public async Task<OperationResult> PutAsync(string resource, object body = null, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(resource, Method.Put, body, cancellationToken);
    }

    public async Task<OperationResultList<T>> PutAsync<T>(string resource, object body = null, CancellationToken cancellationToken = default)
        where T : BaseModel
    {
        return await ExecuteAsync<T>(resource, Method.Put, body, cancellationToken);
    }

    public async Task<OperationResult> DeleteAsync(string resource, object body = null, CancellationToken cancellationToken = default)
    {
        return await ExecuteAsync(resource, Method.Delete, body, cancellationToken);
    }

    public async Task<OperationResultList<T>> DeleteAsync<T>(string resource, object body = null, CancellationToken cancellationToken = default)
        where T : BaseModel
    {
        return await ExecuteAsync<T>(resource, Method.Delete, body, cancellationToken);
    }

    private async Task CheckAuthorized()
    {
        if (_cache.Get<CookieCollection>(_config.AppConfig.Credential.Username).Result == OperationStatus.Success)
            return;

        var authResult = await Authenticate("api/login");
        if (authResult.Result == OperationStatus.Success)
            return;

        await Authenticate("api/auth/login");
    }

    private async Task<OperationResult> Authenticate(string resource = "api/login")
    {
        var request = CreateRequest(resource, Method.Post, _config.AppConfig.Credential);
        if (request == null)
            return OperationResult.Fail();

        var response = await _client.ExecuteAsync<BaseResponseModel<BaseModel>>(request);

        if (!response.IsSuccessful || response.Cookies == null)
            return OperationResult.Fail();

        return _cache.Add(_config.AppConfig.Credential.Username, response.Cookies);

    }

    private async Task<OperationResult> ExecuteAsync(string resource, Method method, object? body = null, CancellationToken cancellationToken = default, bool checkAuthorized = true)
    {
        if (checkAuthorized)
            await CheckAuthorized();

        var request = CreateRequest(resource, method, body);
        if (request == null)
            return null;

        var response = await _client.ExecuteAsync<BaseResponseModel<BaseModel>>(request, cancellationToken);

        if (!response.IsSuccessful || response.Data?.Meta.ResultCode == ResultCodeState.Error)
            return OperationResult.Fail();

        return OperationResult.Success();

    }

    private async Task<OperationResultList<T>> ExecuteAsync<T>(string resource, Method method, object? body = null, CancellationToken cancellationToken = default, bool checkAuthorized = true)
        where T : BaseModel
    {
        if (checkAuthorized)
            await CheckAuthorized();

        var request = CreateRequest(resource, method, body);
        if (request == null)
            return null;

        var response = await _client.ExecuteAsync<BaseResponseModel<T>>(request, cancellationToken);

        if (!response.IsSuccessful)
            return OperationResultList<T>.Fail();

        return new OperationResultList<T>
        {
            Result = OperationStatus.Success,
            Values = response.Data!.Data as List<T>
        };
    }

    private RestRequest CreateRequest(string resource, Method method, object? body = null)
    {
        var request = new RestRequest($"{_baseUrl}/{resource}", method) { RequestFormat = DataFormat.Json };

        if (body != null)
            request.AddJsonBody(body);

        var cookies = _cache.Get<CookieCollection>(_config.AppConfig.Credential.Username);

        if (cookies == null || cookies.Result != OperationStatus.Success)
            return request;

        cookies.Value.ToList()
            .ForEach(cookie => request.AddCookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));

        var token = GetCsrfToken(cookies.Value);

        if (token != null)
            request.AddHeader("X-Csrf-Token", token);

        return request;
    }

    private static string? GetCsrfToken(CookieCollection cookies)
    {
        var token = cookies.FirstOrDefault(c => c.Name == "csrf_token")?.Value;
        if (token != null)
            return token;

        var handler = new JwtSecurityTokenHandler();
        var jwtTokenRaw = cookies.FirstOrDefault(c => c.Name == "TOKEN")?.Value;
        return jwtTokenRaw != null 
            ? (string?)handler.ReadJwtToken(jwtTokenRaw).Payload.FirstOrDefault(r => r.Key == "csrfToken").Value
            : null;
    }
}