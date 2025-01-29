using CommonLibrary.DataClasses.Entities;

namespace SpreeviewAPI.Services.Interfaces;
public interface IUserService
{
    User? Create(User user);
    User? Delete(int id);
    User? Edit(int id, User user);
    User? GetById(int id);
    IEnumerable<User>? Index();
}