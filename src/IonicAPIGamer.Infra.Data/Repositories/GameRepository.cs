using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Domain.Interfaces;
using IonicAPIGamer.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace IonicAPIGamer.Infra.Data.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IonicApiGamerDbContext _context;

    public GameRepository(IonicApiGamerDbContext context)
    {
        _context = (IonicApiGamerDbContext)context;
    }

    public void CreateGame(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Game>> GetAll()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game> GetGameById(int id)
    {
        return await _context.Games.Where(g => g.Id == id).FirstOrDefaultAsync();
    }

}
