using ErrorOr;
using MediatR;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Players.Queries.GetPlayer;

public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, ErrorOr<Player>>
{
    private IPlayersRepository _playersRepository;

    public GetPlayerQueryHandler(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository;
    }

    public async Task<ErrorOr<Player>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var result = await _playersRepository.GetByIdAsync(request.id);

        return result is null
            ?  Error.NotFound(description: "Subscription not found")
            : result;
    }
}