using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Application.Interfaces;

public interface IUserService
{
    Task<User> GetUserById(int id);
    void CreateUser(User user);
}