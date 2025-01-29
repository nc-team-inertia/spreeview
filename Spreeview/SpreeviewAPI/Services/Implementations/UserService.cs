using CommonLibrary.DataClasses.Entities;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class UserService : IUserService
{
    public IEnumerable<User>? Index()
    {
        return new List<User>();
    }

    public User? GetById(int id)
    {
        return new User();
    }

    public User? Create(User user)
    {
        return new User();
    }

    public User? Edit(int id, User user)
    {
        return new User();
    }

    public User? Delete(int id)
    {
        return new User();
    }
}
