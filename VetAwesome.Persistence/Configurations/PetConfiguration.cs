using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Entities.EntityIds;

namespace VetAwesome.Persistence.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            petId => petId.Value,
            value => new PetId(value));

        builder.Property(e => e.Name).HasMaxLength(25);

        builder.HasOne<PetBreed>()
            .WithMany()
            .HasForeignKey(e => e.BreedId);

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(e => e.OwnerId);
    }
}
