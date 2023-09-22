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

    public Game GetGameById(int id)
    {
        return _gameRepository.GetGameById(id);
    }
}
