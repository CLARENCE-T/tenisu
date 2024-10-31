using System.Text.Json.Serialization;

namespace Tenisu.Domain.PlayerAggregate;

public class PlayersList
{    
    [JsonPropertyName("players")] 
    public List<Player> Players { get; set; }
}