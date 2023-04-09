﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Entities.EntityIds;

namespace VetAwesome.Persistence.Configurations;

public class PetBreedConfiguration : IEntityTypeConfiguration<PetBreed>
{
    public void Configure(EntityTypeBuilder<PetBreed> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            petBreedId => petBreedId.Value,
            value => new PetBreedId(value));

        builder.Property(e => e.Name).HasMaxLength(100);

        builder.HasOne<PetType>()
            .WithMany()
            .HasForeignKey(e => e.PetTypeId);
    }
}