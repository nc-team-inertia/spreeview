using System.Text.Json;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiHealth;

public class ApiHealthService : IApiHealthService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiHealthService> _logger;
    
    // json serializer options to use camelCase
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public ApiHealthService(HttpClient httpClient, ILogger<ApiHealthService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<ServiceObjectResponse<CommonLibrary.DataClasses.ApiHealthModel.ApiHealth>> GetHealthAsync()
    {
        try
        {
            // Contact backend
            var result = await _httpClient.GetAsync("api/health/");

            // Commented out, due to 503 status code of "/api/health" Unhealthy responses
            //// If not successful
            //if (!result.IsSuccessStatusCode)
            //{
            //    return new ServiceObjectResponse<CommonLibrary.DataClasses.ApiHealthModel.ApiHealth>()
            //    {
            //        Type = ServiceResponseType.Failure,
            //        Messages = ["Failed to get server health. Endpoint response did not indicate success."]
            //    };
            //}
        
            // Read response contents
            var content = await result.Content.ReadAsStringAsync();
        
            // Deserialize the result
            var health = JsonSerializer.Deserialize<CommonLibrary.DataClasses.ApiHealthModel.ApiHealth>(content, _jsonSerializerOptions);
        
            // Success
            return new ServiceObjectResponse<CommonLibrary.DataClasses.ApiHealthModel.ApiHealth>() { Type = ServiceResponseType.Success , Value = health};
        }
        catch (Exception e)
        {
            _logger.LogInformation("Could not check health due to server error.");
            return new ServiceObjectResponse<CommonLibrary.DataClasses.ApiHealthModel.ApiHealth>();
        }
    }
}
