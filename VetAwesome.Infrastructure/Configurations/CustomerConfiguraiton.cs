using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Entities.EntityIds;

namespace VetAwesome.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                id => id.Value,
                value => new CustomerId(value));

        builder.Property(e => e.Name).HasMaxLength(25).IsRequired(true);
        builder.Property(e => e.StreetAddress).HasMaxLength(250).IsRequired(true);
        builder.Property(e => e.City).HasMaxLength(15).IsRequired(true);
        builder.Property(e => e.ZipCode).HasMaxLength(10).IsRequired(true);
        builder.Property(e => e.StateId).IsRequired(true);
        builder.Property(e => e.Phone).HasMaxLength(10).IsRequired(true);

        builder.HasOne<State>()
            .WithMany()
            .HasForeignKey(e => e.StateId);
    }
}
