using ErrorOr;
using MediatR;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Application.TennisPlayers.Queries.ListTennisPlayers;

public record ListTennisPlayersQuery() : IRequest<ErrorOr<List<Player>>>;
