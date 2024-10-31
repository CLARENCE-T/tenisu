using Microsoft.EntityFrameworkCore;
using Tenisu.Application.Common.Interfaces;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Infrastructure.Persistence.Repositories;

public class PlayersRepository : IPlayersRepository
{
    private readonly TenisuDbContext _context;
    
    public PlayersRepository(TenisuDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Player>> ListAllAsync()
    {
        var players = await _context.Players
            .Include(p => p.Country)
            .Include(p => p.Data) 
            .ToListAsync();
        //TODO null case
        return players;
    }
    
    public async Task<Player?> GetByIdAsync(int id)
    {

        var player = await _context.Players
            .Include(p => p.Country)
            .Include(p => p.Data) 
            .SingleOrDefaultAsync(p => p.Id == id);

        return player;        
    }
}