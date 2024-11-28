using Microsoft.AspNetCore.Mvc;
using SoccerPlayerCatalog.DAL.Entities;

namespace SoccerPlayerCatalog.Modules.SoccerPlayerModule;

public interface ISoccerPlayerService
{
    Task<ActionResult<IEnumerable<SoccerPlayerEntity>>> GetSoccerPlayers();
    Task<IEnumerable<SoccerPlayerEntity>> GetSoccerPlayersData();
    Task<ActionResult<SoccerPlayerEntity>> GetSoccerPlayer(Guid id);
    Task<ActionResult<SoccerPlayerEntity>> CreateOrUpdateSoccerPlayer(SoccerPlayerEntity userEntity);
    Task<ActionResult> DeleteSoccerPlayer(Guid id);
    Task<List<string>> GetTeamsAsync();
    Task AddSoccerPlayerAsync(SoccerPlayerEntity player);
    
}