using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Domain.Entities;
using IonicApiGaner.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace IonicApiGamer.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<User> GetById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost]
        [Route("Create")]
        public void Create(UserModel userModel)
        {
            User user = new User(userModel.Name, userModel.BirthDate);

            _userService.CreateUser(user);
        }
    }
}
