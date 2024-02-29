using System.ComponentModel.DataAnnotations;

namespace GameShop.Dtos.GameTypes;

public class GameTypeDto
{
    public long Id { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }
}
