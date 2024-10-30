using System.Text.Json.Serialization;
using Tenisu.Domain.Common;

namespace Tenisu.Domain.TennisPlayerAggregate;
    
public class Country : Entity
{
    public Country(
        string code, 
        string? pictureUrl = null)
            : base(IdIncrementer.GetNextId<Country>())
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        PictureUrl = pictureUrl;
    }
    public string Code { get; private init; }
    
    [JsonPropertyName("picture")]
    public string? PictureUrl { get; private init; }
}