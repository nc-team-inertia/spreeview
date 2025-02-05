using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiSeries;

public class ApiSeriesService : IApiSeriesService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiSeriesService> _logger;

    public ApiSeriesService(HttpClient httpClient, ILogger<ApiSeriesService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<ServiceObjectResponse<List<SeriesGetDTO>>> GetTrendingSeries()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<List<SeriesGetDTO>>(
					$"trending");

				Console.WriteLine(_httpClient.BaseAddress + "/trending");
				
				if (response != null)
				{
					Console.WriteLine(response[0].BannerPath);
					return new ServiceObjectResponse<List<SeriesGetDTO>>() { Type = ServiceResponseType.Success, Value = response };
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw new Exception(ex.Message);
			}
			return new ServiceObjectResponse<List<SeriesGetDTO>>() { Type = ServiceResponseType.Failure };
		}

		public async Task<ServiceObjectResponse<SeriesGetDTO>> GetSeriesById(int id)
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<SeriesGetDTO>(
					$"{id}");

				if (response != null)
				{
					Console.WriteLine(response);
					return new ServiceObjectResponse<SeriesGetDTO>() { Type = ServiceResponseType.Success, Value = response };
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw new Exception(ex.Message);
			}
			return new ServiceObjectResponse<SeriesGetDTO>() { Type = ServiceResponseType.Failure };
		}

		public async Task<ServiceObjectResponse<List<SeriesGetDTO>>> FindSeriesByKeyword([FromQuery] string query)
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<List<SeriesGetDTO>>(
					$"search?query={query}");

				if (response != null)
				{
					Console.WriteLine(response);
					return new ServiceObjectResponse<List<SeriesGetDTO>>() { Type = ServiceResponseType.Success, Value = response };
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw new Exception(ex.Message);
			}
			return new ServiceObjectResponse<List<SeriesGetDTO>>() { Type = ServiceResponseType.Failure };
		}
}