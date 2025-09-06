using System.ComponentModel.DataAnnotations;
using Authentication.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers;

[ApiController]
[Route("api/[controller]/authentication/users")]
public class AuthenticationController(
    IRavenDbService ravenDbService, 
    IRedisService redisService) 
    : ControllerBase
{
    private readonly IRedisService _redisService = redisService;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsers([Required] [FromRoute] string id)
    {
        await Task.Yield();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUse()
    {
        await Task.Yield();
        return Ok();
    }
}