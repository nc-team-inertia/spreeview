using CommonLibrary.DataClasses.EpisodeModel;
using CommonLibrary.DataClasses.SeasonModel;
using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SpreeviewFrontend.Requests
{
	// TODO: Update this to use typed http client instead of creating directly in this class
	//  this allows for more granular configuration, and avoids hardcoding URIs.
	// TODO: Consider splitting Season and Series functionality into separate service classes (different typed http clients)
	// TODO: Use logger instead of ConsoleWriteLine - gives more specific error
	public class Backend
	{
		public async Task<List<SeriesGetDTO>?> GetTrendingSeries()
		{
			try
			{
				var http = new HttpClient();

				var response = await http.GetFromJsonAsync<List<SeriesGetDTO>>(
					$"https://localhost:7119/api/Series/trending");

				if (response != null)
				{
					Console.WriteLine(response[0].BannerPath);
					return response;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw new Exception(ex.Message);
			}
			return null;
		}

		public async Task<SeriesGetDTO?> GetSeriesById(int id)
		{
			try
			{
				var http = new HttpClient();

				var response = await http.GetFromJsonAsync<SeriesGetDTO>(
					$"https://localhost:7119/api/Series/{id}");

				if (response != null)
				{
					Console.WriteLine(response);
					return response;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw new Exception(ex.Message);
			}
			return null;
		}

        public async Task<SeasonGetDTO?> GetSeasonById(int seriesId, int seasonNumber)
        {
            try
            {
                var http = new HttpClient();

                var response = await http.GetFromJsonAsync<SeasonGetDTO>(
                    $"https://localhost:7119/api/Season/{seriesId}/{seasonNumber}");

                if (response != null)
                {
                    Console.WriteLine(response);
                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception(ex.Message);
            }
            return null;
        }

		public async Task<List<SeriesGetDTO>?> FindSeriesByKeyword([FromQuery] string query)
		{
			try
			{
				var http = new HttpClient();

				var response = await http.GetFromJsonAsync<List<SeriesGetDTO>>(
					$"https://localhost:7119/api/Series/search?query={query}");

				if (response != null)
				{
					Console.WriteLine(response);
					return response;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				throw new Exception(ex.Message);
			}
			return null;
		}

        public async Task<EpisodeGetDTO?> GetIndividualEpisode(int seriesId, int seasonNumber, int episodeNumber)
        {
            try
            {
                var http = new HttpClient();

                var response = await http.GetFromJsonAsync<EpisodeGetDTO>(
                    $"https://localhost:7119/api/Episode/{seriesId}/{seasonNumber}/{episodeNumber}");

                if (response != null)
                {
                    Console.WriteLine(response);
                    return response;
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
}
