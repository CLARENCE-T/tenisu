using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenisu.Domain.TennisPlayerAggregate;

namespace Tenisu.Infrastructure.Persistence.Configurations;

public class TennisPlayerConfiguration : IEntityTypeConfiguration<TennisPlayer>
{
    public void Configure(EntityTypeBuilder<TennisPlayer> builder)
    {
        builder.OwnsOne(x => x.Information, y =>
        {
            y.Property(z => z.Rank).HasColumnName("Rank");
            y.Property(z => z.Points).HasColumnName("Points");
            y.Property(z => z.Weight).HasColumnName("Weight");
            y.Property(z => z.Height).HasColumnName("Height");
            y.Property(z => z.Age).HasColumnName("Age");
            y.Property(z => z.Last).HasColumnName("Last");
        });
        
    }
}