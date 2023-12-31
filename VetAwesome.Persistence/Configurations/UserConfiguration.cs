﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Users;

namespace VetAwesome.Persistence.Configurations;

public partial class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("User");

        entity.Property(e => e.FirstName)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);
        entity.Property(e => e.LastName)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
        .HasForeignKey(d => d.UserRoleId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_User_UserRole");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<User> entity);
}