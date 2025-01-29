using CommonLibrary.DataClasses.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;
[ApiController]
[Route("api/[controller]")]
public class UserController : Controller, IUserController
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        return View();
    }

    [HttpPut("{id}")]
    public ActionResult Edit(int id, User user)
    {
        return View();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return View();
    }
}
