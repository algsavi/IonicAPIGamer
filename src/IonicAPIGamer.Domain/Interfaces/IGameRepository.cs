using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Domain.Interfaces;

public interface IGameRepository
{
    Task<List<Game>> GetAll();
    Task<Game> GetGameById(int id);
    void CreateGame(Game game);
}
