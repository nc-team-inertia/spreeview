using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiIdentity;

public class ApiIdentityService : IApiIdentityService
{
    private readonly HttpClient _httpClient; 
    
    public ApiIdentityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceObjectResponse<int>?> GetUserIdAsync()
    {
        try
        {
			var response = await _httpClient.GetFromJsonAsync<int>($"/identity");
            Console.WriteLine("User ID:");
            Console.WriteLine(response);
			if (response != null)
			{
				return new ServiceObjectResponse<int>() { Type = ServiceResponseType.Success, Value = response };
			}
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: failed to get User ID: {e}");
        }
		return new ServiceObjectResponse<int>() { Type = ServiceResponseType.Failure };
	}

    public async Task<ServiceObjectResponse<string>> GetUserNameByIdAsync(int userId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"identity/{userId}");
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ServiceObjectResponse<string>() { Type = ServiceResponseType.Success, Value = content };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: failed to get User Name by ID: {e}");
        }
        return new ServiceObjectResponse<string>() { Type = ServiceResponseType.Failure, Value = "" };
    }
}
