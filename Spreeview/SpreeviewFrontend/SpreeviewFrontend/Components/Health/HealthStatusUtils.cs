namespace SpreeviewFrontend.Components.Health;

public class HealthStatusUtils
{
    public static HealthStatus StringToHealthStatus(string healthStatus)
    {
        return healthStatus switch
        {
            "Healthy" => HealthStatus.Healthy,
            "Unhealthy" => HealthStatus.Unhealthy,
            "Unknown" => HealthStatus.Unknown,
            _ => HealthStatus.Unhealthy
        };
    }
}