using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tenisu.Domain;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Infrastructure.Persistence;

public class TenisuDbContext : DbContext
{
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<PlayerInformation> PlayersInformations { get; set; } = null!;


    public TenisuDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tenisu.db"); // Utilisation de SQLite
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}