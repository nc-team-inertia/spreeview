using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;
[ApiController]
[Route("/api/[controller]")]
public class SeriesController : Controller, ISeriesController
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet("{id}")]
    public ActionResult Details(int id)
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Series series)
    {
        return View();
    }

    [HttpPut("{id}")]
    public ActionResult Edit(int id, Series series)
    {
        return View();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return View();
    }
}
