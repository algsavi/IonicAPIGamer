using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Domain.Interfaces;
using IonicApiGaner.Model.Models;

namespace IonicAPIGamer.Application.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRegameRepository)
    {
        _gameRepository = gameRegameRepository;
    }

    public void CreateGame(GameModel game)
    {
        var newGame = new Game(game.Name, game.Price);

        _gameRepository.CreateGame(newGame);
    }

    public async Task<GameModel> GetGameById(int id)
    {
        var game = await _gameRepository.GetGameById(id);

        return new GameModel { Name = game.Name, Price = game.Price };
    }

    public async Task<IEnumerable<GameModel>> GetGames()
    {
        var games = await _gameRepository.GetAll();

        return games.Select( g =>
            new GameModel {  Name = g.Name, Price = g.Price }
        );
    }

    public async void InactiveGame(int id)
    {
        var game = _gameRepository.GetGameById(id).Result;

        game.InactiveGame();

        _gameRepository.InactiveGame(game);
    }
}
