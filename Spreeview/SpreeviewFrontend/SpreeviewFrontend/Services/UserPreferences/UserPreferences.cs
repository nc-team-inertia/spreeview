namespace SpreeviewFrontend.Services;

public class UserPreferences
{
    private static Theme theme = Theme.Light;
    public Theme Theme {
        get { return theme; }
        set { theme = value; }
    }
}