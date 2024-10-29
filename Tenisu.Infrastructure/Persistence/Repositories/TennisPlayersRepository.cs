using System.Text.Json;
using ErrorOr;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Infrastructure.TennisPlayers.Persistence;

public class TennisPlayersRepository : ITennisPlayersRepository
{
    
    private readonly string _jsonFilePath = "../headtohead.json";
    
    public async Task<ErrorOr<List<TennisPlayer>>> ListAllAsync()
    {

        if (!File.Exists(_jsonFilePath))
        {
            return Error.NotFound();
        }

        using var stream = File.OpenRead(_jsonFilePath);
        
        return await JsonSerializer.DeserializeAsync<List<TennisPlayer>>(stream);
    }
}