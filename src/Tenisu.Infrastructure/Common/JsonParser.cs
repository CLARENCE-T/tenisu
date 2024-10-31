using System.Text.Json;
using ErrorOr;
using Microsoft.Extensions.Configuration;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Infrastructure.Common;

public class JsonParser
{
    private readonly string _jsonFilePath;

    public JsonParser(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public async Task<ErrorOr<PlayersList>> ParseDataJsonFile()
    {
        if (!File.Exists(_jsonFilePath))
        {
            {
                Console.WriteLine("Json file not found {0}", _jsonFilePath);
                Console.WriteLine($"Current directory: {Directory.GetCurrentDirectory()}");
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