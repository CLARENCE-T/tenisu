using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenisu.Domain.PlayerAggregate;

namespace Tenisu.Infrastructure.Persistence.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Firstname)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(p => p.Lastname)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(p => p.Shortname)
                .HasMaxLength(10);
            
            builder.Property(p => p.Sex)
                .IsRequired()
                .HasMaxLength(1);
            
            builder.Property(p => p.Picture)
                .HasMaxLength(200);
            
            builder.
                HasOne(p => p.Country)
                .WithMany()
                .HasForeignKey(p => p.CountryId);

                builder
                .HasOne(p => p.Data)
                .WithMany()
                .HasForeignKey(p => p.InformationId);
        }
    }
}