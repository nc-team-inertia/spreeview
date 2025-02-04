namespace SpreeviewAPI.Wrappers;

/// <summary>
/// A generic wrapper class for service layer responses that return type T.
/// </summary>
public class ServiceObjectResponse<T> : ServiceResponse
{
    public T? Value { get; set; } = default(T?);
}