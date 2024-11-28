using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoccerPlayerCatalog.DAL.Entities;

namespace SoccerPlayerCatalog.Modules.SoccerPlayerModule;

public class SoccerPlayerService(ISoccerPlayerRepository repository, IMapper mapper) : ControllerBase, ISoccerPlayerService
{
    public async Task<ActionResult<IEnumerable<SoccerPlayerEntity>>> GetSoccerPlayers()
    {
        var soccerPlayers = await repository.ToListAsync();
        return Ok(soccerPlayers);
    }
    
    public async Task<IEnumerable<SoccerPlayerEntity>> GetSoccerPlayersData()
    {
        var soccerPlayers = await repository.ToListAsync();
        return soccerPlayers ?? Enumerable.Empty<SoccerPlayerEntity>();
    }

    public async Task<ActionResult<SoccerPlayerEntity>> GetSoccerPlayer(Guid id)
    {
        var soccerPlayer = await repository.FindAsync(id);
        if (soccerPlayer == null)
            return NoContent();

        return Ok(soccerPlayer);
    }

    public async Task<ActionResult<SoccerPlayerEntity>> CreateOrUpdateSoccerPlayer(SoccerPlayerEntity soccerPlayerEntity)
    {
        var soccerPlayer = await repository.FindAsync(soccerPlayerEntity.Id);

        if (soccerPlayer == null)
            await repository.AddAsync(soccerPlayerEntity);
        else
            mapper.Map(soccerPlayerEntity, soccerPlayer);

        await repository.SaveChangesAsync();

        return Ok(soccerPlayer);
    }

    public async Task<ActionResult> DeleteSoccerPlayer(Guid id)
    {
        var soccerPlayer = await repository.FindAsync(id);
        repository.Remove(soccerPlayer);

        await repository.SaveChangesAsync();
        return NoContent();
    }
    
    public async Task<List<string>> GetTeamsAsync()
    {
        return await repository.ToListAsync()
            .ContinueWith(t => t.Result.Select(p => p.Team).Distinct().ToList());
    }

    public async Task AddSoccerPlayerAsync(SoccerPlayerEntity player)
    {
        await repository.AddAsync(player);
        await repository.SaveChangesAsync();
    }
}