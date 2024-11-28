using Microsoft.EntityFrameworkCore;
using SoccerPlayerCatalog.DAL.Entities;
using SoccerPlayerCatalog.Infrastructure;

namespace SoccerPlayerCatalog.DAL;

public class AppDbContext : DbContext
{
    public DbSet<SoccerPlayerEntity> SoccerPlayers { get; set; }
    private readonly Config config;

    public AppDbContext(DbContextOptions<AppDbContext> options, Config config) : base(options)
    {
        this.config = config;

        /*Database.EnsureDeleted();
        Database.EnsureCreated();*/
        
        SeedData();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder
            .UseNpgsql(config.DbConnectionString,
                builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
        base.OnConfiguring(optionsBuilder);
    }
    
    private void SeedData()
    {
        if (SoccerPlayers.Any())
            return;
        
        SoccerPlayers.AddRange(
            new SoccerPlayerEntity
            {
                Firstname = "John", Surname = "Doe", Gender = "Мужской", Team = "Team A",
                Country = Country.CountryEnum.Russia, BirthDate = DateTime.Parse("1995-05-10")
            },
            new SoccerPlayerEntity
            {
                Firstname = "Jane", Surname = "Doe", Gender = "Женский", Team = "Team B",
                Country = Country.CountryEnum.USA, BirthDate = DateTime.Parse("1992-03-20")
            },
            new SoccerPlayerEntity
            {
                Firstname = "Doe", Surname = "Doe", Gender = "Мужской", Team = "Team C",
                Country = Country.CountryEnum.Italy, BirthDate = DateTime.Parse("1992-03-20")
            }
        );

        SaveChanges();
    }
}