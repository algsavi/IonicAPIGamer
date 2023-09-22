using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Application.Interfaces;

public interface IGameService
{
    Task<List<Game>> GetGames();
    Task<Game> GetGameById(int id);
    void CreateGame(Game game);
}