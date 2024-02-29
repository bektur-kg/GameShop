using GameShop.Configurations;
using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DbContexts;
public class AppDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameType> GameTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //todo change to assembly
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new GameTypeConfiguraion());
    }
}
