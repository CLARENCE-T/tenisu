using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenisu.Domain;

namespace Tenisu.Infrastructure.Persistence.Configurations;

public class PlayerInformationConfiguration : IEntityTypeConfiguration<PlayerInformation>
{
    public void Configure(EntityTypeBuilder<PlayerInformation> builder)
    {
        builder.HasKey(pi => pi.Id);
        builder.Property(pi => pi.Rank).IsRequired();
        builder.Property(pi => pi.Points).IsRequired();
        builder.Property(pi => pi.Weight).IsRequired();
        builder.Property(pi => pi.Height).IsRequired();
        builder.Property(pi => pi.Age).IsRequired();

    }
}