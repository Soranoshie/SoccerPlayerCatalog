using SoccerPlayerCatalog.Infrastructure;

namespace SoccerPlayerCatalog.Modules.SoccerPlayerModule;

public class SoccerPlayerModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<ISoccerPlayerService, SoccerPlayerService>();
        services.AddScoped<ISoccerPlayerRepository, SoccerPlayerRepository>();
        services.AddAutoMapper(typeof(SoccerPlayerMapping));
        
        return services;
    }
}