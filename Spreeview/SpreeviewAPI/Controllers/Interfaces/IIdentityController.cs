using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface IIdentityController
{
    Task<ActionResult> Logout([FromBody] object empty);
}