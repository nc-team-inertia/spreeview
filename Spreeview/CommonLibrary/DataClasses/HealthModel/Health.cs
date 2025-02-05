namespace CommonLibrary.DataClasses.HealthModel;

public class Health
{
    public string OverallStatus { get; set; } = string.Empty;
    public Dictionary<string, HealthCheck> Results { get; set; } = [];
}