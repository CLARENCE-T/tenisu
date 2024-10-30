using ErrorOr;
using MediatR;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Application.TennisPlayers.Queries.ListTennisPlayers;

public class ListTennisPlayersQueryHandler : IRequestHandler<ListTennisPlayersQuery, ErrorOr<List<Player>>>
{
    private ITennisPlayersRepository _tennisPlayersRepository;

    public ListTennisPlayersQueryHandler(ITennisPlayersRepository tennisPlayersRepository)
    {
        _tennisPlayersRepository = tennisPlayersRepository;
    }

    public async Task<ErrorOr<List<Player>>> Handle(ListTennisPlayersQuery request, CancellationToken cancellationToken)
    {
        ErrorOr<List<Player>> result = await _tennisPlayersRepository.ListAllAsync();

        return result;
    }
}