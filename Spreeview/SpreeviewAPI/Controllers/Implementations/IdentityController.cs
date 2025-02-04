using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;
using SpreeviewAPI.Models;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
public class IdentityController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    : ControllerBase, IIdentityController
{
    [Authorize]
    [HttpPost("/logout")]
    public async Task<IActionResult> Logout([FromBody] object empty)
    {
        if (empty is not null)
        {
            await signInManager.SignOutAsync();

            return Ok();
        }
        return Unauthorized();
    }
}
