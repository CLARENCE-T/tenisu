using ErrorOr;
using MediatR;
using Tenisu.Domain.Common.ValueObjects;

namespace Tenisu.Application.Statistics.Queries.GetMixedStatistics;

public record GetMixedStatisticsQuery() : IRequest<ErrorOr<MixedStatistics>>;