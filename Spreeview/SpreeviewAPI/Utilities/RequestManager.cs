namespace SpreeviewAPI.Utilities;

public class RequestManager : IRequestManager
{
    private readonly IHttpClientFactory _httpClientFactory;
    public RequestManager(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T?> TmdbGetAsync<T>(string urlSuffix)
    {
        HttpClient httpClient;
        T? responseValue;

        try
        {
            using (httpClient = _httpClientFactory.CreateClient("tmdb"))
            {
                responseValue = await httpClient.GetFromJsonAsync<T>(urlSuffix);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error has occured: {ex.Message}");
            responseValue = default(T);
        }

        return responseValue;
    }
}
