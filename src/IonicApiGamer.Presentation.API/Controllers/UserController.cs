using IonicApiGamer.Model.ApiReturn;
using IonicApiGamer.Model.Constants;
using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Application.Services;
using IonicAPIGamer.Domain.Entities;
using IonicApiGaner.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public async Task<UserReturn> GetById(int id)
        {
            UserReturn dataToReturn = new UserReturn();

            try
            {
                UserModel result = await _userService.GetUserById(id);

                dataToReturn.Message = Constants.OK_RETURN;
                dataToReturn.User = result;
            }
            catch (Exception ex)
            {
                dataToReturn.Message = ex.Message;
            }

            return dataToReturn;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ResultReturn> Create(UserModel userModel)
        {
            ResultReturn result = new ResultReturn();

            try
            {
                _userService.CreateUser(userModel);

                result.Message = Constants.OK_RETURN;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpPut]
        [Route("InactiveUser")]
        public async Task<ResultReturn> InactiveUser(int id)
        {
            ResultReturn result = new ResultReturn();

            try
            {
                _userService.InactiveUser(id);

                result.Message = Constants.OK_RETURN;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
