using CommonLibrary.DataClasses.SeasonModel;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations
{
    public class SeasonService : ISeasonService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SeasonService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async virtual Task<Season?> FindSeasonByIds(int seriesId, int seasonNumber)
		{
			HttpClient client;
			Season? returnedSeason;

			string urlSuffix = $"/tv/{seriesId}/season/{seasonNumber}";

			try
			{
				using (client = _httpClientFactory.CreateClient("tmdb"))
				{
					returnedSeason = await client.GetFromJsonAsync<Season>(urlSuffix);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				returnedSeason = null;
			}

			return returnedSeason;
		}
	}
}
