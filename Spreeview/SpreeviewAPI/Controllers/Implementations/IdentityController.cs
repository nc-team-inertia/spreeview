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

    [Authorize]
    [HttpGet("/identity")]
    public async Task<ActionResult> GetUserId()
    {
        var user = await userManager.GetUserAsync(User);
        return Ok(user.Id);
    }

    [HttpGet("/identity/{userId:int}")]
    public async Task<ActionResult> GetUserNameById(int userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        string email = user!.UserName!;

        // "Creating" username from registered e-mail, until username registration is added
        string userName = email.Split("@")[0];
        return Ok(userName);
    }
}
