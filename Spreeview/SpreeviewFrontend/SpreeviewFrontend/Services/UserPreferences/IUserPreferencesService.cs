namespace SpreeviewFrontend.Services;

public interface IUserPreferencesService
{
     Task<UserPreferences> GetUserPreferencesAsync();
}