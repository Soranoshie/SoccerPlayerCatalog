using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerPlayerCatalog.DAL.Entities;

public class SoccerPlayerEntity
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Team { get; set; }
    public Country.CountryEnum Country { get; set; }
    
    [NotMapped]
    public bool IsEditable { get; set; }
}