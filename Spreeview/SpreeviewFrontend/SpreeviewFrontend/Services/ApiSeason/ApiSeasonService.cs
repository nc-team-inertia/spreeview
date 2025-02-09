﻿using CommonLibrary.DataClasses.SeasonModel;
using SpreeviewAPI.Wrappers;
using SpreeviewFrontend.Services.ApiReview;

namespace SpreeviewFrontend.Services.ApiSeason;

public class ApiSeasonService : IApiSeasonService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiSeasonService> _logger;

    public ApiSeasonService(HttpClient httpClient, ILogger<ApiSeasonService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<ServiceObjectResponse<SeasonGetDTO>> GetSeasonById(int seriesId, int seasonNumber)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SeasonGetDTO>(
                $"api/season/{seriesId}/{seasonNumber}");

            if (response != null)
            {
                Console.WriteLine(response);
                return new ServiceObjectResponse<SeasonGetDTO>() { Type = ServiceResponseType.Success, Value = response};
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw new Exception(ex.Message);
        }
        return null;
    }
}