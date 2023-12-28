using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.PetBreeds;

namespace VetAwesome.Persistence.Configurations;

public partial class PetBreedConfiguration : IEntityTypeConfiguration<PetBreed>
{
    public void Configure(EntityTypeBuilder<PetBreed> entity)
    {
        entity.ToTable("PetBreed");

        entity.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        entity.HasOne(d => d.PetType).WithMany(p => p.PetBreeds)
        .HasForeignKey(d => d.PetTypeId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_PetBreed_PetType");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<PetBreed> entity);
}
