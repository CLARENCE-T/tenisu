using ErrorOr;
using MediatR;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Application.TennisPlayers.Queries.ListTennisPlayers;

public class ListTennisPlayersQueryHandler : IRequestHandler<ListTennisPlayersQuery, ErrorOr<List<TennisPlayer>>>
{
    private ITennisPlayersRepository _tennisPlayersRepository;

    public ListTennisPlayersQueryHandler(ITennisPlayersRepository tennisPlayersRepository)
    {
        _tennisPlayersRepository = tennisPlayersRepository;
    }

    public async Task<ErrorOr<List<TennisPlayer>>> Handle(ListTennisPlayersQuery request, CancellationToken cancellationToken)
    {
        ErrorOr<List<TennisPlayer>> result = await _tennisPlayersRepository.ListAllAsync();

        return result;
    }
}