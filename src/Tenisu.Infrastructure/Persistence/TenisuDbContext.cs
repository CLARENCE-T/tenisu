using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Infrastructure.Persistence;

public class TenisuDbContext : DbContext
{
    public DbSet<Player> TennisPlayers { get; set; } = null!;

    public TenisuDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }

}