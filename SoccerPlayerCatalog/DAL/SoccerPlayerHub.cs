using Microsoft.AspNetCore.SignalR;
using SoccerPlayerCatalog.DAL.Entities;

namespace SoccerPlayerCatalog.DAL;

public class SoccerPlayerHub : Hub
{
    public Task UpdateList(List<SoccerPlayerEntity> list)
    {
        return Clients.All.SendAsync("UpdateList", list);
    }
}