using System.Text.Json.Serialization;
using Tenisu.Domain.Common;

namespace Tenisu.Domain.PlayerAggregate;

public class Player : Entity
{
    public string Firstname { get;  set; }
    
    public string Lastname { get;  set; }
    
    public string Shortname { get;  set; }
    
    public string Sex { get;  set; }

    public Country Country { get;  set; }

    public int CountryId { get; init; }
    
    public int InformationId { get; init; }
    
    public string Picture { get;  set; }

    public PlayerInformation Data { get;  set; }

}