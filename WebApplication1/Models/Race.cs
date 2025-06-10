using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models;

public class Race
{
    [Key]
    public int RaceId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Location { get; set; }
    public DateTime Date { get; set; }

    public ICollection<TrackRace> TrackRaces { get; set; }
}