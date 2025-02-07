namespace SpreeviewFrontend.Services.ApiIdentity;



public class ApiIdentityService : IApiIdentityService
{
    private readonly HttpClient _httpClient; 
    
    public ApiIdentityService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("SpreeviewAPI");
        _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress, "identity/");
    }

    public async Task<int> GetUserIdAsync()
    {
        try
        {
            var result = await _httpClient.GetAsync("");
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            return int.Parse(content);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return 0;
    }
}