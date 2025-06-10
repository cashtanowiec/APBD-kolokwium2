using WebApplication1.DTO;

namespace WebApplication1.Services;

public interface ITrackRacesService
{
    Task Add(AddTrackRaceDTO addTrackRaceDto);
}