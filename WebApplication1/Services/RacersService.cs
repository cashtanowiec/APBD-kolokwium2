using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.DAL;
using WebApplication1.Exceptions;

namespace WebApplication1.Services;
public class RacersService : IRacersService
{
    private readonly DatabaseContext _context;
    public RacersService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<GetRacerDTO> Get(int id)
    {

        var data = await _context.Racers.Where(r => r.RacerId == id).Select(r => new GetRacerDTO
        {
            RacerId = id,
            FirstName = r.FirstName,
            LastName = r.LastName,
            Participations = r.RaceParticipations.Select(rp => new GetParticipationDTO
            {
                Race = new RaceDTO
                {
                    Name = rp.TrackRace.Race.Name,
                    Location = rp.TrackRace.Race.Location,
                    Date = rp.TrackRace.Race.Date
                },
                Track = new TrackDTO()
                {
                    Name = rp.TrackRace.Track.Name,
                    LengthInKm = rp.TrackRace.Track.LengthInKm
                },
                Laps = rp.TrackRace.Laps,
                FinishTimeInSeconds = rp.FinishTimeInSeconds,
                Position = rp.Position
            }).ToList()
        }).FirstOrDefaultAsync();

        if (data is null)
            throw new NotFoundException("Racer not found");

        return data;
    }
}