namespace SpreeviewFrontend.Services.ApiIdentity;



public class ApiIdentityService : IApiIdentityService
{
    private readonly HttpClient _httpClient; 
    
    public ApiIdentityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetUserIdAsync()
    {
        try
        {
            var result = await _httpClient.GetAsync("identity/");
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