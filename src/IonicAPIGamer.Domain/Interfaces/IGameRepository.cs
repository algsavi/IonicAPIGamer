using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Domain.Interfaces;

public interface IGameRepository
{
    Game GetGameById(int id);
    void CreateGame(Game game);
}
