using GameShop.Dtos.GameTypes;
using GameShop.Models;

namespace GameShop.Services;

public interface IGameTypeService
{
    void AddGameType(GameTypeCreationDto gameType);
    Task<List<GameTypeDto>> GetGameTypes();
}
