using ErrorOr;
using MediatR;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.Common.ValueObjects;

namespace Tenisu.Application.Statistics.Queries.GetMixedStatistics;

public class GetMixedStatisticsQueryHandler : IRequestHandler<GetMixedStatisticsQuery, ErrorOr<MixedStatistics>>
{
    private IPlayersRepository _playersRepository;

    public GetMixedStatisticsQueryHandler(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository;
    }

    public async Task<ErrorOr<MixedStatistics>> Handle(GetMixedStatisticsQuery request, CancellationToken cancellationToken)
    {
        //get country that have more victories
        var players = await _playersRepository.ListAllAsync();
        var countryWins = players
            .GroupBy(p => p.Country)
            .Select(group => new
            {
                Country = group.Key,
                TotalWins = group.Sum(player => player.Data.Last.Count(result => result == 1))
            })
            .OrderByDescending(x => x.TotalWins)
            .FirstOrDefault();
        
        
        //calcule average BMI for every players 
        var averageBMI = Math.Round(players
            .Where(player => player.Data.Weight > 0 && player.Data.Height > 0)
            .Select(player =>
            {
                double weightInKg = player.Data.Weight / 1000.0;
                double heightInMeters = player.Data.Height / 100.0;
                return weightInKg / (heightInMeters * heightInMeters);
            })
            .Average(), 2);
        
        //calcul median Height of all players  
        var heights = (await _playersRepository.ListAllAsync())
            .Where(player => player.Data.Height > 0) 
            .Select(player => player.Data.Height)
            .OrderBy(height => height)
            .ToList();

        int medianHeight;
        int count = heights.Count;
        if (count == 0)
        {
            throw new InvalidOperationException("Aucun joueur avec une taille valide n'a été trouvé.");
        }

        // Calculer la médiane
        if (count % 2 == 1)
        {
            medianHeight = heights[count / 2];
        }
        else
        {
            medianHeight =  ((heights[(count / 2) - 1] + heights[count / 2]) / 2);
        }
        return new MixedStatistics(new CountryWins(countryWins.Country, countryWins.TotalWins), averageBMI, medianHeight);
    }
}

