﻿using System.Text.Json;
using CommonLibrary.DataClasses.ApiHealthModel;
using CommonLibrary.DataClasses.ApiHealthModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.HealthCheck;

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

    public async Task<ServiceObjectResponse<ApiHealth>> GetHealthAsync()
    {
        try
        {
            // Contact backend
            var result = await _httpClient.GetAsync("");

            // If not successful
            if (!result.IsSuccessStatusCode)
            {
                return new ServiceObjectResponse<ApiHealth>()
                {
                    Type = ServiceResponseType.Failure,
                    Messages = ["Failed to get server health. Endpoint response did not indicate success."]
                };
            }
        
            // Read response contents
            var content = await result.Content.ReadAsStringAsync();
        
            // Deserialize the result
            var health = JsonSerializer.Deserialize<ApiHealth>(content, _jsonSerializerOptions);
        
            // Success
            return new ServiceObjectResponse<ApiHealth>() { Type = ServiceResponseType.Success , Value = health};
        }
        catch (Exception e)
        {
            _logger.LogInformation("Could not check health due to server error.");
            return new ServiceObjectResponse<ApiHealth>();
        }
    }
}