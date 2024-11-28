using AutoMapper;
using SoccerPlayerCatalog.DAL.Entities;

namespace SoccerPlayerCatalog.Modules.SoccerPlayerModule;

public class SoccerPlayerMapping : Profile
{
    public SoccerPlayerMapping()
    {
        CreateMap<SoccerPlayerEntity, SoccerPlayerEntity>();
    }
}