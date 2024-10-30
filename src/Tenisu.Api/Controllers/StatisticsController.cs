using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tenisu.Application.Statistics.Queries.GetMixedStatistics;

namespace Tenisu.Api.Controllers;

public class StatisticsController(ISender sender) : ApiController
{
    //TODO Get mixed information statistics 
    [HttpGet(ApiEndpoints.Statistics.GetMixedStatistics)]
    public async Task<IActionResult> GetMixedStatistics()
    {
        //country that have the better player rank
        GetMixedStatisticsQuery query = new();
        
        var result= await sender.Send(query);

        return Ok(result.Value);
    }
}