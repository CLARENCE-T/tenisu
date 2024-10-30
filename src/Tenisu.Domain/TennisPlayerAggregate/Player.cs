using System.Text.Json.Serialization;
using Tenisu.Domain.Common;

namespace Tenisu.Domain.TennisPlayerAggregate;

public class Player : Entity
{
    public string Firstname { get; private init; }
    
    public string Lastname { get; private set; }
    
    public string Shortname { get; private set; }
    
    public string Sex { get; private set; }
    
    public Country Country { get; private set; }
    
    [JsonPropertyName("picture")]
    public string PictureUrl { get; private set; }

    [JsonPropertyName("data")]
    public PlayerInformation Information { get; private set; }

    public Player(int id, string firstname, string lastname, string shortname, string sex, Country country,
        string pictureUrl, PlayerInformation information) : base(id)
    {
        Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        Shortname = shortname ?? throw new ArgumentNullException(nameof(shortname));
        Sex = sex ?? throw new ArgumentNullException(nameof(sex));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        PictureUrl = pictureUrl ?? throw new ArgumentNullException(nameof(pictureUrl));
        Information = information ?? throw new ArgumentNullException(nameof(information));
    }
}