using AutoMapper;
using GameShop.DbContexts;
using GameShop.Dtos.Games;
using GameShop.Models;
using GameShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IGamesService _gameService;
    private readonly IMapper _mapper;

    public GameController(AppDbContext dbContext, IGamesService gameService, IMapper mapper)
    {
        _dbContext = dbContext;
        _gameService = gameService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> GetGames()
    {
        return Ok(await _gameService.GetGamesAsync());
    }

    [HttpGet("{gameId}")]
    public async Task<ActionResult> GetGame(int gameId)
    {
        var game = await _gameService.GetGameAsync(gameId);

        if (game == null)
        {
            return NotFound();
        }

        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult> AddGame(GameCreationDto game)
    {
        _gameService.AddGame(game);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{gameId}")]
    public async Task<IActionResult> RemoveGame(int gameId)
    {
        var game = await _gameService.GetGameAsync(gameId);

        if (game == null)
        {
            return NotFound();
        }

        await _gameService.DeleteGame(gameId);

        return NoContent();
    }

    [HttpPut("{gameId}")]
    public async Task<IActionResult> FullUpdateGame(int gameId, GameFullUpdateDto updatedGame)
    {
        var game = await _gameService.GetGameAsync(gameId);

        if (game == null)
        {
            return NotFound();
        }

        await _gameService.FullUpdateGame(game, updatedGame);

        return NoContent();
    }
}
