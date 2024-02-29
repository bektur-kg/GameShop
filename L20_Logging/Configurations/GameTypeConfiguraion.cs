using GameShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameShop.Configurations;

public class GameTypeConfiguraion : IEntityTypeConfiguration<GameType>
{
    public void Configure(EntityTypeBuilder<GameType> builder)
    {
        builder
            .HasMany(t => t.Games)
            .WithOne(g => g.GameType)
            .HasForeignKey(g => g.GameTypeId);
    }
}
