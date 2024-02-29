using GameShop.Dtos.Games;
using GameShop.Models;

namespace GameShop.Services;

public interface IGamesService
{
    Task<List<GameDto>> GetGamesAsync();

    Task<Game?> GetGameAsync(int gameId);

    void AddGame(GameCreationDto game);

    Task DeleteGame(int gameId);

    Task FullUpdateGame(Game gameToUpdate, GameFullUpdateDto updatedGame);
}
