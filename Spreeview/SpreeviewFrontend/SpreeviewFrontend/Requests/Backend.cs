using CommonLibrary.DataClasses.SeriesModel;
using System.Text.Json;

namespace SpreeviewFrontend.Requests
{
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
	}
}
