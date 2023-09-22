using IonicAPIGamer.Domain.Entities;
using IonicApiGaner.Model.Models;

namespace IonicAPIGamer.Application.Interfaces;

public interface IGameService
{
    Task<IEnumerable<GameModel>> GetGames();
    Task<GameModel> GetGameById(int id);
    void CreateGame(GameModel game);
    void InactiveGame(int id);
}