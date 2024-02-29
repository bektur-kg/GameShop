namespace GameShop.Dtos.Games;

public class GameCreationDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public long GameTypeId { get; set; }
}
