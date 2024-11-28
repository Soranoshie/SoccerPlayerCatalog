namespace SoccerPlayerCatalog.DAL.Entities;

public class SoccerPlayerViewModel
{
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string SelectedTeam { get; set; }
    public string NewTeam { get; set; }
    public Country.CountryEnum Country { get; set; }
}