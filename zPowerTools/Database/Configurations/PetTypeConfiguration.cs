﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.Database.Configurations
{
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
}
