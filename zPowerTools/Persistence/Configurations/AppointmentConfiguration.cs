using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;

#nullable disable

namespace VetAwesome.Persistence.Configurations;

public partial class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> entity)
    {
        entity.Property(e => e.EndTime).HasColumnType("datetime");

        entity.Property(e => e.StartTime).HasColumnType("datetime");

        entity.HasOne(d => d.Pet)
            .WithMany(p => p.Appointments)
            .HasForeignKey(d => d.PetId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Appointments_Pets");

        entity.HasOne(d => d.Veterinarian)
            .WithMany(p => p.Appointments)
            .HasForeignKey(d => d.VeterinarianId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Appointments_Users");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Appointment> entity);
}
