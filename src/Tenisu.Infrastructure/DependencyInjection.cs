using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Infrastructure.Common;
using Tenisu.Infrastructure.Persistence;
using Tenisu.Infrastructure.Persistence.Configurations;
using Tenisu.Infrastructure.Persistence.Repositories;

namespace Tenisu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddPersistence(configuration);
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
    {
        //TODO: add path of json file
        var jsonFilePath = configuration["JsonFilePath"];

        services.AddDbContext<TenisuDbContext>(options =>
            options.UseSqlite("Data Source = GymManagement.db"));

        services.AddScoped<IPlayersRepository, PlayersRepository>();
        services.AddScoped<DatabaseInitializer>();
        services.AddSingleton<JsonParser>(provider => new JsonParser(jsonFilePath));
        

        return services;
    }
}