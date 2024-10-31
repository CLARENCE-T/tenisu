using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tenisu.Domain;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Infrastructure.Persistence;

public class TenisuDbContext : DbContext
{
    public TenisuDbContext(DbContextOptions<TenisuDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Player> Players { get; set; } = null!;
    
    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<PlayerInformation> PlayersInformations { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tenisu.db"); // Utilisation de SQLite
    }
}