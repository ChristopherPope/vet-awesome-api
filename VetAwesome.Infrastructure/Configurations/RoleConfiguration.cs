using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

#nullable disable

namespace VetAwesome.Infrastructure.Configurations;

public partial class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entity)
    {
        entity.ToTable(TableNames.Roles);
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Role> entity);
}
