using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.States;

namespace VetAwesome.Persistence.Configurations;

public partial class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> entity)
    {
        entity.ToTable("State");

        entity.Property(e => e.Abbreviation)
        .IsRequired()
        .HasMaxLength(2)
        .IsUnicode(false);
        entity.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<State> entity);
}
