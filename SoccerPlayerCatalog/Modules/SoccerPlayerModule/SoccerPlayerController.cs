using Microsoft.AspNetCore.Mvc;
using SoccerPlayerCatalog.DAL.Entities;

namespace SoccerPlayerCatalog.Modules.SoccerPlayerModule;

[ApiController]
[Route("api/[controller]")]
public class SoccerPlayerController(ISoccerPlayerService soccerPlayerService) : ControllerBase
{
    /// <summary>
    /// Получить всех футболистов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<ActionResult<IEnumerable<SoccerPlayerEntity>>> GetSoccerPlayers()
        => soccerPlayerService.GetSoccerPlayers();

    /// <summary>
    /// Получить футболиста по id
    /// </summary>
    /// <param name="id">id футболиста</param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public Task<ActionResult<SoccerPlayerEntity>> GetSoccerPlayer([FromRoute] Guid id)
        => soccerPlayerService.GetSoccerPlayer(id);

    /// <summary>
    /// Удалить футболиста по id
    /// </summary>
    /// <param name="id">id футболиста</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public Task<ActionResult> DeleteSoccerPlayer([FromRoute] Guid id)
        => soccerPlayerService.DeleteSoccerPlayer(id);

    /// <summary>
    /// Создание или обновление футболиста
    /// </summary>
    /// <param name="soccerPlayer"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<ActionResult<SoccerPlayerEntity>> CreateOrUpdateSoccerPlayer([FromBody] SoccerPlayerEntity soccerPlayer)
        => soccerPlayerService.CreateOrUpdateSoccerPlayer(soccerPlayer);
}