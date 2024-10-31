using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Application.Players.Queries.GetPlayer;
using Tenisu.Application.Players.Queries.ListPlayers;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Api.Controllers;

public class PlayersController(ISender sender) : ApiController
{
    //TODO Get all endpoint
    
    [HttpGet(ApiEndpoints.Players.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        ListPlayersQuery query = new ();
        
        ErrorOr<List<Player>> result = await sender.Send(query);
        
        if (result.IsError)
            return Problem();
        
        return Ok(result.Value);
    }
    
    //TODO Get by id endpoint
    [HttpGet(ApiEndpoints.Players.Get)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetPlayerQuery query = new(id);
        var result = await sender.Send(query);
        
        if (result.IsError) 
            return Problem(result.Errors.ToString());
        
        return Ok(result.Value);
    }
}