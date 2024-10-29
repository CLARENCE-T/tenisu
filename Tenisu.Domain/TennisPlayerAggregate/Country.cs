using Tenisu.Domain.Common;

namespace Tenisu.Domain.TennisPlayerAggregate;
    
public class Country : Entity
{
    public Country(int id, string code, string? pictureUrl = null) : base(id)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        PictureUrl = pictureUrl;
    }

    public string Code { get; private init; }

    public string? PictureUrl { get; private init; }
}