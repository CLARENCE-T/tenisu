using ErrorOr;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Application.Common.Interfaces;

public interface ITennisPlayersRepository
{
    Task<ErrorOr<List<Player>>> ListAllAsync();

}