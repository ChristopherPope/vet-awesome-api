﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;

#nullable disable

namespace VetAwesome.Persistence.Configurations;

public partial class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> entity)
    {
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.HasOne(d => d.Customer)
            .WithMany(p => p.Pets)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Pets_Customers");

        entity.HasOne(d => d.PetBreed)
            .WithMany(p => p.Pets)
            .HasForeignKey(d => d.PetBreedId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Pets_PetBreeds");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Pet> entity);
}
