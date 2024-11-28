using Microsoft.EntityFrameworkCore.ChangeTracking;
using SoccerPlayerCatalog.DAL.Entities;

namespace SoccerPlayerCatalog.Modules.SoccerPlayerModule;

public interface ISoccerPlayerRepository
{
    Task<SoccerPlayerEntity?> FindAsync(Guid id);
    public Task<int> SaveChangesAsync();
    public Task<EntityEntry<SoccerPlayerEntity>> AddAsync(SoccerPlayerEntity soccerPlayer);
    public Task<List<SoccerPlayerEntity>> ToListAsync();
    public void Remove(SoccerPlayerEntity soccerPlayer);
    public EntityEntry<SoccerPlayerEntity> Update(SoccerPlayerEntity soccerPlayer);
}