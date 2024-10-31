namespace Tenisu.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class TenisuDbContextFactory : IDesignTimeDbContextFactory<TenisuDbContext>
{
    public TenisuDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TenisuDbContext>();
        optionsBuilder.UseSqlite("Data Source=GymManagement.db"); // Assurez-vous que la chaîne de connexion est correcte

        return new TenisuDbContext(optionsBuilder.Options);
    }
}