using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Services;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/{controller}")]
public class RacersController : ControllerBase
{
    private readonly IRacersService _racersService;
    public RacersController(IRacersService racersService)
    {
        _racersService = racersService;
    }
    
    [HttpGet("{id}/participations")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var data = await _racersService.Get(id);
            return Ok(data);
        }
        catch (NotFoundException exc)
        {
            return NotFound(exc.Message);
        }
    }
}