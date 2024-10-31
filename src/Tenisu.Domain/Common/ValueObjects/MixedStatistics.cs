using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Domain.Common.ValueObjects;

public record MixedStatistics(CountryWins countryWins, double averageBMI, int medianHeight);