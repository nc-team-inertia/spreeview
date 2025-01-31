using System.Text.Json;
using CommonLibrary.DataClasses.SeriesModel;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class SeriesService : ISeriesService
{
    public IEnumerable<Series>? Index()
    {
        return new List<Series>();
    }

    public async Task<Series>? GetById(int id)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.themoviedb.org/3/tv/{id}?language=en-US"),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmNWQyOGExMWE5Y2M3MmZmZTIzODY3OGRlYmJjMjA2ZCIsIm5iZiI6MTczODE1MTIyMS44MDQ5OTk4LCJzdWIiOiI2NzlhMTUzNTQ5ZmJlNDY5MDFjMGQzMjIiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.2NNpOwKxlQvEdoZVEwq431ySCOfnByYTd_UYFMQRHN4" },
            },
        };
        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);
        var res =  JsonSerializer.Deserialize<Series>(body);
        return res;
    }
}
