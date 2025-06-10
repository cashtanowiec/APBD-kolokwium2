using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/track-races")]
public class TrackRacesController : ControllerBase
{
    private readonly ITrackRacesService _trackRacesService;
    public TrackRacesController(ITrackRacesService trackRacesService)
    {
        _trackRacesService = trackRacesService;
    }
    
    [HttpPost("participants")]
    public async Task<IActionResult> Add(AddTrackRaceDTO addTrackRaceDto)
    {
        try
        {
            await _trackRacesService.Add(addTrackRaceDto);
            return Ok();
        }
        catch (NotFoundException exc)
        {
            return NotFound(exc.Message);
        }
        catch (ConflictException exc)
        {
            return Conflict(exc.Message);
        }
    }
}