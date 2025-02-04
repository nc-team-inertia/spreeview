using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
public class IdentityController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    : ControllerBase, IIdentityController
{
    [Authorize]
    [Route("/logout")]
    public async Task<ActionResult> Logout([FromBody] object empty)
    {
        if (empty is not null)
        {
            await signInManager.SignOutAsync();

            return Ok();
        }
        return Unauthorized();
    }
}