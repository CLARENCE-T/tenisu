using Tenisu.Domain.Common;

namespace Tenisu.Domain;

public class TennisPlayerInformation : Entity
{
    public string Rank{ get; private init; }
    
    public string Points { get; private init; }
    
    public string Weight { get; private init; }
    
    public string Height { get; private init; }
    
    public string Age { get; private init; }
    
    public List<int> Last { get; private init; }

    public TennisPlayerInformation(int id, string rank, string points, string weight, string height, string age, List<int> last) : base(id)
    {
        Rank = rank ?? throw new ArgumentNullException(nameof(rank));
        Points = points ?? throw new ArgumentNullException(nameof(points));
        Weight = weight ?? throw new ArgumentNullException(nameof(weight));
        Height = height ?? throw new ArgumentNullException(nameof(height));
        Age = age ?? throw new ArgumentNullException(nameof(age));
        Last = last ?? throw new ArgumentNullException(nameof(last));
    }
}