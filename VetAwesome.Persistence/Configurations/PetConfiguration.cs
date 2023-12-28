using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Pets;

namespace VetAwesome.Persistence.Configurations;

public partial class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> entity)
    {
        entity.ToTable("Pet");

        entity.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        entity.HasOne(d => d.Customer).WithMany(p => p.Pets)
        .HasForeignKey(d => d.CustomerId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Pet_Customer");

        entity.HasOne(d => d.PetBreed).WithMany(p => p.Pets)
        .HasForeignKey(d => d.PetBreedId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Pet_PetBreed");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Pet> entity);
}
