using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Api.Controllers;

public class TennisPlayersController : ApiController
{
    private ISender _sender;

    public TennisPlayersController(ISender sender)
    {
        _sender = sender;
    }

    //Get all endpoint
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        
        List<TennisPlayer> result = await _sender.Send();
        return Ok();
    }
    //Get by id endpoint 
    //Get mixte information statistics 
        //country that have the better player rank 
        //medium IMC of all players
        //mediane of player's height 
}