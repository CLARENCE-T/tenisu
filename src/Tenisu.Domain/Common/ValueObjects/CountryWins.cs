using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Domain.Common.ValueObjects;

public record CountryWins(Country Country, int TotalWins);