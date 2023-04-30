using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

#nullable disable

namespace VetAwesome.Infrastructure.Configurations;

public partial class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> entity)
    {
        entity.ToTable(TableNames.States);
        entity.Property(e => e.Abbreviation)
            .HasMaxLength(2)
            .IsUnicode(false);

        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<State> entity);
}
