using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI;

public static class WebApplicationExtensions
{
    // TODO: Use a controller to manage this
    public static void AddLogoutEndpoint(this WebApplication app)
    {
        app.MapPost("/logout", async (SignInManager<IdentityUser<int>> signInManager, [FromBody] object empty) =>
        {
            if (empty is not null)
            {
                await signInManager.SignOutAsync();

                return Results.Ok();
            }

            return Results.Unauthorized();
        }).RequireAuthorization();
    }
    
    // TODO: User a controller to manage this
    // TODO: Do we need this at all?
    public static void AddRolesEndpoint(this WebApplication app)
    {
        // provide an endpoint for user roles
        app.MapGet("/roles", (ClaimsPrincipal user) =>
        {
            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)user.Identity;
                var roles = identity.FindAll(identity.RoleClaimType)
                    .Select(c => 
                        new
                        {
                            c.Issuer, 
                            c.OriginalIssuer, 
                            c.Type, 
                            c.Value, 
                            c.ValueType
                        });

                return TypedResults.Json(roles);
            }

            return Results.Unauthorized();
        }).RequireAuthorization();
    }
}