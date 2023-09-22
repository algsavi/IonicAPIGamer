using IonicAPIGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace IonicAPIGamer.Infra.Data.Context;

public class IonicApiGamerDbContext : DbContext
{
    public IonicApiGamerDbContext()
    {
    }

    public IonicApiGamerDbContext(DbContextOptions<IonicApiGamerDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Server=ionicapidb;Database=APIGamer;User Id=sa;Password=p@ssw0rd;TrustServerCertificate=True;");


    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
