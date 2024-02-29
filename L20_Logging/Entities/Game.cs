using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameShop.Models;

public class Game
{
    public long Id { get; set; }

    [StringLength(250)]
    public required string Name { get; set; }

    [Precision(10, 2)]
    public decimal Price { get; set; }

    [StringLength(600)]
    public string? Description { get; set; }
    public long GameTypeId { get; set; }
    public GameType? GameType { get; set; }
}
