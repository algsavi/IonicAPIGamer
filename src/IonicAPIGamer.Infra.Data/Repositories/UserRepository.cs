using IonicAPIGamer.Domain.Entities;
using IonicAPIGamer.Domain.Interfaces;
using IonicAPIGamer.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace IonicAPIGamer.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IonicApiGamerDbContext _context;

    public UserRepository(IonicApiGamerDbContext context)
    {
        _context = (IonicApiGamerDbContext)context;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    public void InactiveUser(User user)
    {
        _context.Users.Attach(user);
        _context.Entry(user).Property(x => x.IsActive).IsModified = true;
        _context.SaveChanges();
    }

    void IUserRepository.CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}
