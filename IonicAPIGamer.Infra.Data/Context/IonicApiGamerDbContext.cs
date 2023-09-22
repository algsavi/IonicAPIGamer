using IonicAPIGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IonicAPIGamer.Infra.Data.Context;

public class IonicApiGamerDbContext : DbContext
{
    public IonicApiGamerDbContext(DbContextOptions<IonicApiGamerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Games)
            .WithOne(g => g.User)
            .HasForeignKey(g => g.UserId);

        base.OnModelCreating(modelBuilder);
    }
}
