using Tenisu.Domain.Common.ValueObjects;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Application.Statistics.Services;

public interface IStatisticsService
{
    Task<int> GetMedianHeightAsync();
    
    Task<CountryWins> GetCountriesWithTheBestPlayerRankingsAsync();
    
    Task<double> GetAverageBmiAsync();
}