namespace WebApplication1.DTO;

public class AddTrackRaceDTO
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public ICollection<AddParticipationDTO> Participations { get; set; }
}

public class AddParticipationDTO
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}