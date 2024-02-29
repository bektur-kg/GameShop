using AutoMapper;
using GameShop.Dtos.Games;
using GameShop.Models;

namespace GameShop.Profiles;

public class GamesProfile : Profile
{
	public GamesProfile()
	{
		CreateMap<GameCreationDto, Game>();
		CreateMap<Game, GameDto>();
		CreateMap<GameFullUpdateDto, Game>();
	}
}
