using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Infrastructure.Persistence;
using Tenisu.Infrastructure.TennisPlayers.Persistence;

namespace Tenisu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationBuilder configuration)
    {
        return services
            .AddPersistence();
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        //TODO: add path of json file
        
        services.AddDbContext<TenisuDbContext>(options =>
            options.UseSqlite("Data Source = GymManagement.db"));

        services.AddScoped<ITennisPlayersRepository, TennisPlayersRepository>();

        return services;
    }
}