using Tenisu.Domain.Common;

namespace Tenisu.Domain.PlayerAggregate;
    
public class Country : Entity
{
    public string Code { get;  init; }
    public string? Picture { get;  init; }
    
}