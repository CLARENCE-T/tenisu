using ErrorOr;
using MediatR;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Players.Queries.GetPlayer;


public record GetPlayerQuery(int id) : IRequest<ErrorOr<Player>>;
