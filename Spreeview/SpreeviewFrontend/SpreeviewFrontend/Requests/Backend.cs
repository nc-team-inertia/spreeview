using CommonLibrary.DataClasses.SeriesModel;
using System.Text.Json;

namespace SpreeviewFrontend.Requests
{
	public class Backend
	{
		public async Task<List<Series>?> GetTrendingSeries()
		{
			try
			{
				var http = new HttpClient();

				var response = await http.GetFromJsonAsync<List<Series>>(
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
	}
}
