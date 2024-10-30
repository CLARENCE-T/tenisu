using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        
        builder.HasKey(c => c.Id);
        
        // builder.HasAlternateKey(c => c.Code);
        
        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(3); // Code de pays en 3 caractères
        
        builder.Property(c => c.Picture)
            .HasMaxLength(200); // URL de l'image, optionnelle
    }
}