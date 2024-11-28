namespace SoccerPlayerCatalog.Infrastructure;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection services);
}