using ErrorOr;
using MediatR;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Application.Statistics.Services;
using Tenisu.Domain.Common.ValueObjects;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Statistics.Queries.GetMixedStatistics;

public class GetMixedStatisticsQueryHandler(
    IPlayersRepository playersRepository, 
    IStatisticsService statisticsService)
        : IRequestHandler<GetMixedStatisticsQuery, ErrorOr<MixedStatistics>>
{
    private readonly IPlayersRepository _playersRepository = playersRepository;

    public async Task<ErrorOr<MixedStatistics>> Handle(GetMixedStatisticsQuery request, CancellationToken cancellationToken)
    {
        
        //get Country that have more victories
        var countryWins =  await statisticsService.GetCountriesWithTheBestPlayerRankingsAsync();
        
        //calcule average BMI for every players 
        var averageBmi = await statisticsService.GetAverageBmiAsync();
        
        //calcul median Height of all players  
        var medianHeight = await statisticsService.GetMedianHeightAsync();


        return new MixedStatistics(countryWins, averageBmi, medianHeight);
    }
}

