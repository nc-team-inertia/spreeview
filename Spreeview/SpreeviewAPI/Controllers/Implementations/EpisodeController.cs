using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;

namespace SpreeviewAPI.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class EpisodeController : Controller, IEpisodeController
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
    public ActionResult Create(Episode episode)
    {
        return View();
    }

    [HttpPut("{id}")]
    public ActionResult Edit(int id, Episode episode)
    {
        return View();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return View();
    }
}
