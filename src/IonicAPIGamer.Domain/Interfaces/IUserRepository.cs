using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Domain.Interfaces;

public interface IUserRepository
{
    User GetUserById(int id);
    void CreateUser(User user);
}
