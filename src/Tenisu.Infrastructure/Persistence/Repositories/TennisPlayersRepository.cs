using System.Text.Json;
using ErrorOr;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Infrastructure.Persistence.Repositories;

public class TennisPlayersRepository : ITennisPlayersRepository
{
    
    private readonly string _jsonFilePath = "../Tenisu.Infrastructure/Persistence/headtohead.json";
    
    public async Task<ErrorOr<List<Player>>> ListAllAsync()
    {

        if (!File.Exists(_jsonFilePath))
        {
            return Error.NotFound();
        }
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        using var stream = File.OpenRead(_jsonFilePath);
        var playersList = await JsonSerializer.DeserializeAsync<PlayersList>(stream, options);

        return playersList?.Players ?? new List<Player>();
    }
}