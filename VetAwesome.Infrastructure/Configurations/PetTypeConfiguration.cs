using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Entities.EntityIds;

namespace VetAwesome.Infrastructure.Configurations;

public class PetTypedConfiguration : IEntityTypeConfiguration<PetType>
{
    public void Configure(EntityTypeBuilder<PetType> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                id => id.Value,
                value => new PetTypeId(value));

        builder.Property(e => e.Name).HasMaxLength(100);
    }
}
