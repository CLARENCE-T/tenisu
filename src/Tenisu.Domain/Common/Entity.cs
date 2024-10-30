using System.Text.Json.Serialization;

namespace Tenisu.Domain.Common;

public abstract class Entity
{
    public int Id { get; init; }

    protected Entity(int id) => Id = id;

    protected Entity()
    {
    }

}