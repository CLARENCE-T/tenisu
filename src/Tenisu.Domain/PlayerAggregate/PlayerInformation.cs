using Tenisu.Domain.Common;

namespace Tenisu.Domain;

public class PlayerInformation : Entity
{
    public int Rank { get;  set; }
    
    public int Points { get;  set; }
    
    public int Weight { get;  set; }
    
    public int Height { get;  set; }
    
    public int Age { get;  set; }
    public List<int> Last { get; set; } = new List<int>(); 
    
}