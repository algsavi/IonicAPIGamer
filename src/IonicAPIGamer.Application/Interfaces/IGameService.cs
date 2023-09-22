using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Application.Interfaces;

public interface IGameService
{
    Task<IEnumerable<Game>> GetGames();
    Task<Game> GetGameById(int id);
    void CreateGame(Game game);
}