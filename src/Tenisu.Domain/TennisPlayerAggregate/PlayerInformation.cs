using System.Text.Json.Serialization;
using Tenisu.Domain.Common;

namespace Tenisu.Domain;

public class PlayerInformation : Entity
{
    public int Rank { get; private init; }
    
    public int Points { get; private init; }
    
    public int Weight { get; private init; }
    
    public int Height { get; private init; }
    
    public int Age { get; private init; }
    
    public List<int> Last { get; private init; }

    public PlayerInformation(
        int id, 
        int rank, 
        int points, 
        int weight, 
        int height, 
        int age, 
        List<int> last) 
          : base(IdIncrementer.GetNextId<PlayerInformation>())

    {
        Rank = rank;
        Points = points;
        Weight = weight;
        Height = height;
        Age = age;
        Last = last ?? throw new ArgumentNullException(nameof(last));
    }
}