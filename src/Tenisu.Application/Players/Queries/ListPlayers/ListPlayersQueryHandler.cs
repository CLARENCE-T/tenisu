using ErrorOr;
using MediatR;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Players.Queries.ListPlayers;

public class ListPlayersQueryHandler : IRequestHandler<ListPlayersQuery, ErrorOr<List<Player>>>
{
    private IPlayersRepository _playersRepository;

    public ListPlayersQueryHandler(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository;
    }

    public async Task<ErrorOr<List<Player>>> Handle(ListPlayersQuery request, CancellationToken cancellationToken)
    {
        ErrorOr<List<Player>> result = await _playersRepository.ListAllAsync();

        return result.IsError
            ?  Error.NotFound(description: "Subscription not found")
            : result;
    }
}