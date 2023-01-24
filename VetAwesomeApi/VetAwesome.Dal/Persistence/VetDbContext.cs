using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;

namespace VetAwesome.Dal.Persistence;

public partial class VetDbContext : DbContext
{
    public VetDbContext(DbContextOptions<VetDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentEntity>(entity =>
        {
            entity.ToTable("Appointments");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Customers");

            entity.HasOne(d => d.Pet).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Pets");

            entity.HasOne(d => d.Veterinarian).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.VeterinarianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Users");
        });

        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.ToTable("Customers");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Household).WithMany(p => p.Customers)
                .HasForeignKey(d => d.HouseholdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_Households");
        });

        modelBuilder.Entity<HouseholdEntity>(entity =>
        {
            entity.ToTable("Households");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress1)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.Households)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Households_States");
        });

        modelBuilder.Entity<PetEntity>(entity =>
        {
            entity.ToTable("Pets");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Household).WithMany(p => p.Pets)
                .HasForeignKey(d => d.HouseholdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_Households");

            entity.HasOne(d => d.PetBreed).WithMany(p => p.Pets)
                .HasForeignKey(d => d.PetBreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_PetBreeds");
        });

        modelBuilder.Entity<PetBreedEntity>(entity =>
        {
            entity.ToTable("PetBreeds");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PetType).WithMany(p => p.PetBreeds)
                .HasForeignKey(d => d.PetTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PetBreeds_PetTypes");
        });

        modelBuilder.Entity<PetTypeEntity>(entity =>
        {
            entity.ToTable("PetTypes");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoleEntity>(entity =>
        {
            entity.ToTable("Roles");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StateEntity>(entity =>
        {
            entity.ToTable("States");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("Users");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
