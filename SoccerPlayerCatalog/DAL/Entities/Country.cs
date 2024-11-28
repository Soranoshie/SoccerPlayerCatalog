namespace SoccerPlayerCatalog.DAL.Entities;

public class Country
{
    public enum CountryEnum
    {
        Russia,
        USA,
        Italy
    }
    
    public static string TranslateCountry(string country)
    {
        return country switch
        {
            "Russia" => "Россия",
            "USA" => "США",
            "Italy" => "Италия",
            _ => country.ToString()
        };
    }

}