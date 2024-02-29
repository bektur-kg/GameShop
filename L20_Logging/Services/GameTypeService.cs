using AutoMapper;
using GameShop.DbContexts;
using GameShop.Dtos.GameTypes;
using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Services
{
    public class GameTypeService : IGameTypeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GameTypeService(IMapper mapper, AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void AddGameType(GameTypeCreationDto gameType)
        {
            var newGameType = _mapper.Map<GameType>(gameType); 
            _dbContext.GameTypes.Add(newGameType);
        }

        public async Task<List<GameTypeDto>> GetGameTypes()
        {
            var gameTypes = await _dbContext.GameTypes.ToListAsync();
            var gameTypesToReturn = _mapper.Map<List<GameTypeDto>>(gameTypes);

            return gameTypesToReturn;
        }
    }
}
