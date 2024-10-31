using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Common.Interfaces;

public interface IPlayersRepository
{
    Task<List<Player>> ListAllAsync();
    Task<Player?> GetByIdAsync(int id);

}