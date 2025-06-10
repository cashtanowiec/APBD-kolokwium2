using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.DTO;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class TrackRacesService : ITrackRacesService
{
    private readonly DatabaseContext _context;
    public TrackRacesService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task Add(AddTrackRaceDTO addTrackRaceDto)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var race = await _context.Races.FirstOrDefaultAsync(r => r.Name == addTrackRaceDto.RaceName);
            if (race == null)
                throw new NotFoundException("Race not found");
        
            var track = await _context.Tracks.FirstOrDefaultAsync(t => t.Name == addTrackRaceDto.TrackName);
            if (track == null)
                throw new NotFoundException("Track not found");
        
            var trackRace = await _context.TrackRaces.Where(tr => tr.TrackId == track.TrackId && tr.RaceId == race.RaceId).FirstOrDefaultAsync();
            if (trackRace == null)
                throw new NotFoundException("Race track not found");
            int? bestTime = trackRace.BestTimeInSeconds;
        
            foreach (var participation in addTrackRaceDto.Participations)
            {
                var doesRacerExists = _context.Racers.Any(r => r.RacerId == participation.RacerId);
                if (!doesRacerExists)
                    throw new NotFoundException("Racer not found");
                
                var doesRaceParticipationExist = _context.RaceParticipations.Any(r => r.RacerId == participation.RacerId && r.TrackRaceId == track.TrackId);
                if (doesRaceParticipationExist)
                    throw new ConflictException("Race Participation already exists");
            
                var raceParticipation = new RaceParticipation()
                {
                    TrackRaceId = trackRace.TrackRaceId,
                    RacerId = participation.RacerId,
                    FinishTimeInSeconds = participation.FinishTimeInSeconds,
                    Position = participation.Position
                };
                _context.RaceParticipations.Add(raceParticipation);
            
                if (bestTime == null || participation.FinishTimeInSeconds < bestTime)
                {
                    trackRace.BestTimeInSeconds = participation.FinishTimeInSeconds;
                }
            }
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
        
    }
}