using IonicApiGaner.Model.Models;

namespace IonicApiGamer.Model.ApiReturn;

public class GameListReturn : ResultReturn
{
    public List<GameModel> GameList { get; set; }
}
