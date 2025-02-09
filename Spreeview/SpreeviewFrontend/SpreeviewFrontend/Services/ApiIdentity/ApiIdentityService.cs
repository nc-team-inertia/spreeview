using CommonLibrary.DataClasses.ReviewModel;
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
            Console.WriteLine("User Id");
            Console.WriteLine(response);
			if (response != null)
			{
				return new ServiceObjectResponse<int>() { Type = ServiceResponseType.Success, Value = response };
			}
        }
        catch (Exception e)
        {
            Console.WriteLine("failed");
            Console.WriteLine(e.Message);
        }
		return new ServiceObjectResponse<int>() { Type = ServiceResponseType.Failure };
	}
}