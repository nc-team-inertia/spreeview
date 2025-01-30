using Microsoft.AspNetCore.Components.Authorization;

namespace SpreeviewFrontend.Client.Identity;

public class CookieAuthenticationStateProvider : AuthenticationStateProvider, IAccountManagement
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}