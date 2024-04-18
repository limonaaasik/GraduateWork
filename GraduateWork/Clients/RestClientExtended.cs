using NLog;
using RestSharp;
using RestSharp.Authenticators;
using GraduateWork.Helpers.Configuration;
using RestSharp.Authenticators.OAuth2;

namespace GraduateWork.Clients;

public sealed class RestClientExtended
{
    private readonly RestClient _client;
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public RestClientExtended()
    {
        var options = new RestClientOptions(Configurator.AppSettings.URI ?? throw new InvalidOperationException())
        {
            Authenticator =
                new OAuth2AuthorizationRequestHeaderAuthenticator("c4b4150f590b68ccb6261af9051c8495bb2d920ca4abf87de7f1172784443df5")
        };

        _client = new RestClient(options);
    }
    
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }

    private void LogRequest(RestRequest request)
    {
        _logger.Debug($"{request.Method} request to: {request.Resource}");

        var body = request.Parameters
            .FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;

        if (body != null)
        {
            _logger.Debug($"body: {body}");
        }
    }

    private void LogResponse(RestResponse response)
    {
        if (response.ErrorException != null)
        {
            _logger.Error(
                $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
        }
        
        _logger.Debug($"Request finished with status code: {response.StatusCode}");

        if (!string.IsNullOrEmpty(response.Content))
        {
            _logger.Debug(response.Content);
        }
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync(request);
        LogResponse(response);

        return response;
    }

    public async Task<T> ExecuteAsync<T>(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync<T>(request);
        LogResponse(response);

        return response.Data ?? throw new InvalidOperationException();
    }
}