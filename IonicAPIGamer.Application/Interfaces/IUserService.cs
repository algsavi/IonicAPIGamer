using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Application.Interfaces;

public interface IUserService
{
    User GetUserById(int id);
    void CreateUser(User user);
}