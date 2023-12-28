using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.PetTypes;

namespace VetAwesome.Persistence.Configurations;

public partial class PetTypeConfiguration : IEntityTypeConfiguration<PetType>
{
    public void Configure(EntityTypeBuilder<PetType> entity)
    {
        entity.ToTable("PetType");

        entity.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<PetType> entity);
}
