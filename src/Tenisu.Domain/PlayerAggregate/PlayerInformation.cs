using Tenisu.Domain.Common;

namespace Tenisu.Domain;

public class PlayerInformation : Entity
{
    public int Rank { get;  init; }
    
    public int Points { get;  init; }
    
    public int Weight { get;  init; }
    
    public int Height { get;  init; }
    
    public int Age { get;  init; }
    public List<int> Last { get; set; } = new List<int>(); 
    
}