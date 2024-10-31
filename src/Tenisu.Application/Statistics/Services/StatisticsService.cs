using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.Common.ValueObjects;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Statistics.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IPlayersRepository _playersRepository;
    
    public StatisticsService(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository;
    }
    
    public async Task<int> GetMedianHeightAsync()
    {
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
        return medianHeight;
    }

    public async Task<CountryWins> GetCountriesWithTheBestPlayerRankingsAsync()
    {
        var result = (await _playersRepository.ListAllAsync())
            .GroupBy(p => p.Country)
            .Select(group => new CountryWins(
                Country: group.Key,
                TotalWins: group.Sum(player => player.Data.Last.Count(result => result == 1))
            )).MaxBy(x => x.TotalWins);

        return result;
    }

    public async Task<double> GetAverageBmiAsync()
    {
        return Math.Round((await _playersRepository.ListAllAsync())
            .Where(player => player.Data.Weight > 0 && player.Data.Height > 0)
            .Select(player =>
            {
                double weightInKg = player.Data.Weight / 1000.0;
                double heightInMeters = player.Data.Height / 100.0;
                return weightInKg / (heightInMeters * heightInMeters);
            })
            .Average(), 2);
    }
}