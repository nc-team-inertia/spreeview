
namespace SpreeviewAPI.Utilities;

public interface IRequestManager
{
    Task<T?> TmdbGetAsync<T>(string urlSuffix);
}