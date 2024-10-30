using System.Text.Json;
using ErrorOr;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Infrastructure.Common;

public class JsonParser
{
    private  readonly string _jsonFilePath = "../Tenisu.Infrastructure/Persistence/headtohead.json";

    public async Task<ErrorOr<PlayersList>> ParseDataJsonFile()
    {
        if (!File.Exists(_jsonFilePath))
        {
            {
                return  Error.NotFound();
            }
        }
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        using var stream = File.OpenRead(_jsonFilePath);
        var playersList = await JsonSerializer.DeserializeAsync<PlayersList>(stream, options);

        if (playersList != null) return playersList;

        return Error.NotFound();
    }
}