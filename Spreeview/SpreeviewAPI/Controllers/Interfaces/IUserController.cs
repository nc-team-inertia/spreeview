using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface IUserController
{
    ActionResult Create(User user);
    ActionResult Delete(int id);
    ActionResult Edit(int id, User user);
    ActionResult GetById(int id);
    ActionResult Index();
}