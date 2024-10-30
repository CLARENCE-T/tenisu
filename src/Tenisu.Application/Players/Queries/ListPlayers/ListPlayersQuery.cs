using ErrorOr;
using MediatR;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Players.Queries.ListPlayers;

public record ListPlayersQuery() : IRequest<ErrorOr<List<Player>>>;
