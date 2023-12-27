﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.Database.Configurations
{
    public partial class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address");

            entity.Property(e => e.City)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false);
            entity.Property(e => e.StreetAddress)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.ZipCode)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.StateId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Address_State");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Address> entity);
    }
}
