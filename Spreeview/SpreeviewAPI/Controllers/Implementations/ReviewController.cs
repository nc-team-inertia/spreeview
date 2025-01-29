using CommonLibrary.DataClasses.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Implementations;
public class ReviewController : Controller
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
    public ActionResult Create(Review review)
    {
        return View();
    }

    [HttpPut("{id}")]
    public ActionResult Edit(int id, Review review)
    {
        return View();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return View();
    }
}

