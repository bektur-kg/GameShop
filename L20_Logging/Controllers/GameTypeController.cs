using GameShop.DbContexts;
using GameShop.Dtos.GameTypes;
using GameShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers;

[ApiController]
[Route("api/game-types")]
public class GameTypeController : ControllerBase
{
    private readonly IGameTypeService _gameTypeService;
    private readonly AppDbContext _dbContext;

    public GameTypeController(IGameTypeService gameTypeService, AppDbContext dbContext)
    {
        _gameTypeService = gameTypeService;
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ActionResult> AddGameType(GameTypeCreationDto gameType)
    {
        _gameTypeService.AddGameType(gameType);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult> GetGameTypes()
    {
        var gameTypes = await _gameTypeService.GetGameTypes();

        return Ok(gameTypes);
    }
}
