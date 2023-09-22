using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Domain.Interfaces;

namespace IonicAPIGamer.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(User user)
    {
        _userRepository.CreateUser(user);
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }
}
