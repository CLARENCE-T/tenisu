using System.Text.Json.Serialization;

namespace Tenisu.Domain.TennisPlayerAggregate;

public class PlayersList
{    
    [JsonPropertyName("players")] 
    public List<Player> Players { get; set; }
}