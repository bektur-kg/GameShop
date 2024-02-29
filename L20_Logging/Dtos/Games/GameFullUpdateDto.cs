using GameShop.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameShop.Dtos.Games;

public class GameFullUpdateDto
{
    [StringLength(250)]
    public required string Name { get; set; }

    [Precision(10, 2)]
    public decimal Price { get; set; }

    [StringLength(600)]
    public string? Description { get; set; }
    public long GameTypeId { get; set; }
}
