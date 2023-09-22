using IonicAPIGamer.Domain.Entities;

namespace IonicAPIGamer.Application.Interfaces;

public interface IGameService
{
    Game GetGameById(int id);
    void CreateGame(Game game);
}