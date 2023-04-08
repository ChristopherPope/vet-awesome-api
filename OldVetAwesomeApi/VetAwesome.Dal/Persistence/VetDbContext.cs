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
            entity.Property(e => e.CellPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.Customers)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_States");
        });

        modelBuilder.Entity<PetEntity>(entity =>
        {
            entity.ToTable("Pets");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Pets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_Customers");

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

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_UserRoles");
        });

        modelBuilder.Entity<UserRoleEntity>(entity =>
        {
            entity.ToTable("UserRoles");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
