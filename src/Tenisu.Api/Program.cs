using Microsoft.EntityFrameworkCore;
using Tenisu.Application;
using Tenisu.Infrastructure;
using Tenisu.Infrastructure.Persistence;
using Tenisu.Infrastructure.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

try
{
    var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<TenisuDbContext>();

    await context.Database.MigrateAsync();
    // seed database from json file
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
    await seeder.SeedAsync();   
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

// app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0:80");
