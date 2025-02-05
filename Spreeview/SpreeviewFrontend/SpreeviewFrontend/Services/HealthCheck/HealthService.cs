using System.Text.Json;
using CommonLibrary.DataClasses.HealthModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.HealthCheck;

public class HealthService : IHealthService
{

    private readonly HttpClient _httpClient;
    private readonly ILogger<HealthService> _logger;
    
    // json serializer options to use camelCase
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    // TODO: Switch to using typed http client instead of named
    public HealthService(IHttpClientFactory httpClientFactory, ILogger<HealthService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("SpreeviewAPI");
        _logger = logger;
    }

    public async Task<ServiceObjectResponse<Health>> GetHealthAsync()
    {
        try
        {
            // Contact backend
            var result = await _httpClient.GetAsync("api/health");

            // If not successful
            if (!result.IsSuccessStatusCode)
            {
                return new ServiceObjectResponse<Health>()
                {
                    Type = ServiceResponseType.Failure,
                    Messages = ["Failed to get server health. Endpoint response did not indicate success."]
                };
            }
        
            // Read response contents
            var content = await result.Content.ReadAsStringAsync();
        
            // Deserialize the result
            var health = JsonSerializer.Deserialize<Health>(content, _jsonSerializerOptions);
        
            // Success
            return new ServiceObjectResponse<Health>() { Type = ServiceResponseType.Success , Value = health};
        }
        catch (Exception e)
        {
            _logger.LogInformation("Could not check health due to server error.");
            return new ServiceObjectResponse<Health>();
        }
    }
}