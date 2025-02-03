namespace SpreeviewFrontend.Services;

public class UserPreferencesService : IUserPreferencesService
{
    public async Task<UserPreferences> GetUserPreferencesAsync()
    {
        return await Task.FromResult(new UserPreferences());
    }
}