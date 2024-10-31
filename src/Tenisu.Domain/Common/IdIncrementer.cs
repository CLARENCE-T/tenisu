using System.Collections.Concurrent;

namespace Tenisu.Domain;

public static class IdIncrementer
{
    // Dictionnaire pour stocker le compteur pour chaque type
    private static readonly ConcurrentDictionary<string, int> _idCounters = new();

    public static int GetNextId<T>()
    {
        var typeName = typeof(T).Name;
        return _idCounters.AddOrUpdate(typeName, 1, (_, currentId) => currentId + 1);
    }
}