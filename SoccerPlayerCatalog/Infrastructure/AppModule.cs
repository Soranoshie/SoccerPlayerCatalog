using Newtonsoft.Json;
using SoccerPlayerCatalog.DAL;

namespace SoccerPlayerCatalog.Infrastructure;

public class AppModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        services.AddDbContext<AppDbContext>();

        return services;
    }
}