namespace SoccerPlayerCatalog.Infrastructure;

public class Config(bool isDevelopment)
{
    public string DbConnectionString { get; } = isDevelopment
        ? "Server=localhost;Database=SoccerPlayerCatalog;Port=5432;User Id=postgres;Password=1"
        : Environment.GetEnvironmentVariable("Connection");
}