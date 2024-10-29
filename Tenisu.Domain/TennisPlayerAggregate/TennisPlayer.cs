using Tenisu.Domain.Common;

namespace Tenisu.Domain.TennisPlayerAggregate;

public class TennisPlayer : Entity
{
    public string Firstname { get; private init; }
    
    public string Lastname { get; private init; }
    
    public string Shortname { get; private init; }
    
    public string Sex { get; private init; }
    
    public Country Country { get; private init; }
    
    public string PictureUrl { get; private init; }

    public TennisPlayerInformation Information { get; private init; }

    public TennisPlayer(int id, string firstname, string lastname, string shortname, string sex, Country country,
        string pictureUrl, TennisPlayerInformation information) : base(id)
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