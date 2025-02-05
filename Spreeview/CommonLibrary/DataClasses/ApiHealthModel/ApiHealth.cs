namespace CommonLibrary.DataClasses.ApiHealthModel;

public class ApiHealth
{
    public string OverallStatus { get; set; } = string.Empty;
    public Dictionary<string, ApiHealthCheck> Results { get; set; } = [];
}