using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Domain.Interfaces;
using IonicApiGaner.Model.Models;

namespace IonicAPIGamer.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(UserModel user)
    {
        var newUser = new User(user.Name, user.BirthDate);

        _userRepository.CreateUser(newUser);
    }

    public async Task<UserModel> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);

        return new UserModel { Name = user.Name, BirthDate = user.BirthDate };
    }

    public async void InactiveUser(int id)
    {
        var user = _userRepository.GetUserById(id).Result;

        user.InactiveUser();

        _userRepository.InactiveUser(user);
    }
}
