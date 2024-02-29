using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Models;

public class GameType
{
    public long Id { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }
    public List<Game>? Games { get; set; }
}
