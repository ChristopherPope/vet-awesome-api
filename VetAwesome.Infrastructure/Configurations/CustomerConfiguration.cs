﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

#nullable disable

namespace VetAwesome.Infrastructure.Configurations;

public partial class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.ToTable(TableNames.Customers);
        entity.Property(e => e.Phone)
            .HasMaxLength(15)
            .IsUnicode(false);

        entity.Property(e => e.City)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.Property(e => e.Name)
            .HasMaxLength(100)
            .IsUnicode(false);

        entity.Property(e => e.StreetAddress)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.Property(e => e.Phone)
            .HasMaxLength(15)
            .IsUnicode(false);

        entity.Property(e => e.ZipCode)
            .HasMaxLength(10)
            .IsUnicode(false);

        entity.HasOne(d => d.State)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.StateId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customers_States");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Customer> entity);
}