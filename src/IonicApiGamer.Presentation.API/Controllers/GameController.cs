﻿using IonicApiGamer.Model.ApiReturn;
using IonicApiGamer.Model.Constants;
using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Infra.Caching;
using IonicApiGaner.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IonicApiGamer.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ICachingService _cachingService;

        public GameController(ICachingService cacheService, IGameService gameService)
        {
            _cachingService = cacheService;
            _gameService = gameService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GameReturn> GetById(int id)
        {
            GameReturn dataToReturn = new GameReturn();

            try
            {
                var cachedGame = await _cachingService.GetAsync(id.ToString());

                GameModel result;

                if (cachedGame != null)
                    result = JsonConvert.DeserializeObject<GameModel>(cachedGame);
                else
                    result = await _gameService.GetGameById(id);

                await _cachingService.SetAsync(id.ToString(), JsonConvert.SerializeObject(result));

                dataToReturn.Message = Constants.OK_RETURN;
                dataToReturn.Game = result;
            }
            catch (Exception ex)
            {
                dataToReturn.Message = ex.Message;
            }

            return dataToReturn;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<GameListReturn> GetAll()
        {
            GameListReturn dataToReturn = new GameListReturn();

            try
            {
                IEnumerable<GameModel> result = await _gameService.GetGames();
                
                dataToReturn.Message = Constants.OK_RETURN;
                dataToReturn.GameList = result.ToList();
            }
            catch (Exception ex)
            {
                dataToReturn.Message = ex.Message;
            }

            return dataToReturn;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ResultReturn> Create(GameModel gameModel)
        {
            ResultReturn result = new ResultReturn();

            try
            {
                _gameService.CreateGame(gameModel);

                result.Message = Constants.OK_RETURN;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpPut]
        [Route("InactiveGame")]
        public async Task<ResultReturn> InactiveGame(int id)
        {
            ResultReturn result = new ResultReturn();

            try
            {
                _gameService.InactiveGame(id);

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
