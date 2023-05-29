#nullable disable


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Configurations;

public partial class PetBreedConfiguration : IEntityTypeConfiguration<PetBreed>
{
    public void Configure(EntityTypeBuilder<PetBreed> entity)
    {
        entity.ToTable(TableNames.PetBreeds);
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.HasOne(d => d.PetType)
            .WithMany(p => p.Breeds)
            .HasForeignKey(d => d.PetTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PetBreeds_PetTypes");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<PetBreed> entity);
}
