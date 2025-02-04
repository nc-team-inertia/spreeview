using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface IIdentityController
{
    Task<IActionResult> Logout([FromBody] object empty);
}