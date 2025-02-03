namespace SpreeviewAPI.Wrappers;

/// <summary>
/// A generic wrapper class for service layer responses that return void.
/// </summary>
public class ServiceResponse
{
    public string[] Messages { get; set; } = [];
    public ServiceResponseType Type { get; set; } = ServiceResponseType.Failure;
}

