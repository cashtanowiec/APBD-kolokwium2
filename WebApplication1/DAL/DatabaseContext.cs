using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DAL;
public class DatabaseContext : DbContext
{
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<Track> Tracks { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Track>().HasData(
            new Track { TrackId = 1, Name = "TEST1", LengthInKm = 123},
            new Track { TrackId = 2, Name = "TEST2", LengthInKm = 200}
        );

        modelBuilder.Entity<Race>().HasData(
            new Race { RaceId = 1, Name = "Big race", Location = "Here and there", Date = DateTime.Parse("1980-01-01")},
            new Race { RaceId = 2, Name = "Small race", Location = "England", Date = DateTime.Parse("1980-05-01")}
        );

        modelBuilder.Entity<Racer>().HasData(
            new Racer { RacerId = 1, FirstName = "Anna", LastName = "Nowak"},
            new Racer { RacerId = 2, FirstName = "Jan", LastName = "Kowal"}
        );

        modelBuilder.Entity<RaceParticipation>().HasData(
            new RaceParticipation { TrackRaceId = 1, RacerId = 1, FinishTimeInSeconds = 2000, Position = 1 },
            new RaceParticipation { TrackRaceId = 1, RacerId = 2, FinishTimeInSeconds = 2500, Position = 2 },
            new RaceParticipation { TrackRaceId = 2, RacerId = 1, FinishTimeInSeconds = 2500, Position = 1 }
        );

        modelBuilder.Entity<TrackRace>().HasData(
            new TrackRace
            {
                TrackRaceId = 1,
                TrackId = 1,
                RaceId = 1,
                Laps = 10,
                BestTimeInSeconds = 2500
            },
            new TrackRace
            {
                TrackRaceId = 2,
                TrackId = 1,
                RaceId = 2,
                Laps = 15,
                BestTimeInSeconds = 2500
            }
        );
        
    }

}