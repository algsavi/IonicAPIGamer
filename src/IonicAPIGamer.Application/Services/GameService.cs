using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Domain.Interfaces;

namespace IonicAPIGamer.Application.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRegameRepository)
    {
        _gameRepository = gameRegameRepository;
    }

    public void CreateGame(Game game)
    {
        _gameRepository.CreateGame(game);
    }

    public async Task<Game> GetGameById(int id)
    {
        return await _gameRepository.GetGameById(id);
    }

    public async Task<IEnumerable<Game>> GetGames()
    {
        return await _gameRepository.GetAll();
    }
}
