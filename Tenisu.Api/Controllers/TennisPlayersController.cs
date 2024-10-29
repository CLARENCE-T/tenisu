using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Application.TennisPlayers.Queries.ListTennisPlayers;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Api.Controllers;

[Route("players")]
public class TennisPlayersController : ApiController
{
    private ISender _sender;

    public TennisPlayersController(ISender sender)
    {
        _sender = sender;
    }

    //TODO Get all endpoint
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ListTennisPlayersQuery query = new ListTennisPlayersQuery();
        ErrorOr<List<TennisPlayer>> result = await _sender.Send(query);
        return Ok();
    }
    
    //TODO Get by id endpoint
    
    
    //TODO Get mixte information statistics 
        //country that have the better player rank 
        //medium IMC of all players
        //mediane of player's height 
}