namespace SpreeviewFrontend.Services;

public class UserPreferences
{
    //TODO make static/consistent throughout the application's lifecycle
    //TODO default to a cookie/localCache instead?

    public Theme Theme { get; set; } = Theme.Light;
}