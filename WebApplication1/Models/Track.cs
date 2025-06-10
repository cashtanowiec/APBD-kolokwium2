using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Track
{
    [Key]
    public int TrackId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [Column(TypeName = "numeric")]
    [Precision(5, 2)]
    public double LengthInKm { get; set; }

    public ICollection<TrackRace> TrackRaces { get; set; }
}