using Microsoft.Extensions.DependencyInjection;
using Tenisu.Application.Statistics.Services;

namespace Tenisu.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        services.AddScoped<IStatisticsService, StatisticsService>();
        return services;
    }
}