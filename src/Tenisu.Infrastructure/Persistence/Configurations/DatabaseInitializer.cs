using Tenisu.Infrastructure.Common;

namespace Tenisu.Infrastructure.Persistence.Configurations;

public class DatabaseInitializer
{    
    private readonly TenisuDbContext _context;
    private readonly JsonParser _parser;

    public DatabaseInitializer(TenisuDbContext context, JsonParser parser)
    {
        _context = context;
        _parser = parser;
    }
    
    public async Task SeedAsync()
    {
        if (_context.Players.Any())
            return;
        
        var playersListResult = await _parser.ParseDataJsonFile();

        if (playersListResult.IsError)
        {
            Console.WriteLine("Erreur lors du parsing du fichier JSON");
            return;
        }
        if (playersListResult.Value.Players.Any())
        {
            foreach (var player in playersListResult.Value.Players)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
            }
        }

    }
}