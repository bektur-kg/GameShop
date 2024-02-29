using AutoMapper;
using GameShop.DbContexts;
using GameShop.Dtos.Games;
using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Services;

public class GamesService : IGamesService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GamesService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Game?> GetGameAsync(int gameId)
    {
        return await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == gameId);
    }

    public async Task<List<GameDto>> GetGamesAsync()
    {
        var games = await _dbContext.Games.ToListAsync();
        return _mapper.Map<List<GameDto>>(games);
    }

    public void AddGame(GameCreationDto game)
    {
        var newGame = _mapper.Map<Game>(game);

        _dbContext.Games.Add(newGame);
    }

    public async Task DeleteGame(int gameId)
    {
        await _dbContext.Games
            .Where(g => g.Id == gameId)
            .ExecuteDeleteAsync();

        await _dbContext.SaveChangesAsync();
    }

    public async Task FullUpdateGame(Game gameToUpdate, GameFullUpdateDto updatedGame)
    {
        _mapper.Map(updatedGame, gameToUpdate);

        await _dbContext.SaveChangesAsync();
    }
}
