using IonicAPIGamer.Domain.Entities;
using IonicApiGaner.Model.Models;

namespace IonicAPIGamer.Application.Interfaces;

public interface IUserService
{
    Task<UserModel> GetUserById(int id);
    void CreateUser(UserModel user);
    void InactiveUser(int id);
}