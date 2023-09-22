using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Domain.Entities;
using IonicApiGaner.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace IonicApiGamer.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Game> GetById(int id)
        {
            return await _gameService.GetGameById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Game>> GetAll()
        {
            return await _gameService.GetGames();
        }

        [HttpPost]
        [Route("Create")]
        public void Create(GameModel gameModel)
        {
            Game game = new Game(gameModel.Name, gameModel.Price);

            _gameService.CreateGame(game);
        }
    }
}
