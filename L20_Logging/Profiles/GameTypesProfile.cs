using AutoMapper;
using GameShop.Dtos.GameTypes;
using GameShop.Models;

namespace GameShop.Profiles;

public class GameTypesProfile : Profile
{
    public GameTypesProfile()
    {
		CreateMap<GameTypeCreationDto, GameType>();
		CreateMap<GameType, GameTypeDto>();
    }
}
