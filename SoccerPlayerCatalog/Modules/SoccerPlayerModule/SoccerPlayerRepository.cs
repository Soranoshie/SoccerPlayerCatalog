using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SoccerPlayerCatalog.DAL;
using SoccerPlayerCatalog.DAL.Entities;

namespace SoccerPlayerCatalog.Modules.SoccerPlayerModule;

public class SoccerPlayerRepository(AppDbContext context) : ISoccerPlayerRepository
{
    public async Task<SoccerPlayerEntity?> FindAsync(Guid id)
        => await context.SoccerPlayers.FindAsync(id);

    public async Task<int> SaveChangesAsync()
        => await context.SaveChangesAsync();

    public async Task<EntityEntry<SoccerPlayerEntity>> AddAsync(SoccerPlayerEntity? soccerPlayerEntity)
        => await context.SoccerPlayers.AddAsync(soccerPlayerEntity);

    public async Task<List<SoccerPlayerEntity>> ToListAsync()
        => await context.SoccerPlayers.ToListAsync();

    public void Remove(SoccerPlayerEntity? soccerPlayerEntity)
        => context.SoccerPlayers.Remove(soccerPlayerEntity);

    public EntityEntry<SoccerPlayerEntity> Update(SoccerPlayerEntity? soccerPlayerEntity)
        => context.SoccerPlayers.Update(soccerPlayerEntity);
}