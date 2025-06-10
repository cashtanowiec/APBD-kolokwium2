namespace WebApplication1.DTO;

public class GetRacerDTO
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<GetParticipationDTO> Participations { get; set; }
}

public class GetParticipationDTO
{
    public RaceDTO Race { get; set; }
    public TrackDTO Track { get; set; }
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceDTO
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
}

public class TrackDTO
{
    public string Name { get; set; }
    public double LengthInKm { get; set; }
}