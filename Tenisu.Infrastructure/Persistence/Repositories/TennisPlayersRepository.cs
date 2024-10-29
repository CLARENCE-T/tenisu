using ErrorOr;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Infrastructure.TennisPlayers.Persistence;

public class TennisPlayersRepository : ITennisPlayersRepository
{
    public Task<ErrorOr<List<TennisPlayer>>> ListAllAsync()
    {
        var tennisPlayers = await _dbContext.TennisPlayers.ToListAsync();
        
        return new ErrorOr<List<TennisPlayer>>(tennisPlayers);
    }
}