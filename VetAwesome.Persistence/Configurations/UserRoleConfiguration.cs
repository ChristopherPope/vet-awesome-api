using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.UserRoles;

namespace VetAwesome.Persistence.Configurations;

public partial class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> entity)
    {
        entity.ToTable("UserRole");

        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserRole> entity);
}
