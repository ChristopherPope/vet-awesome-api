using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Entities.EntityIds;

namespace VetAwesome.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.Property(e => e.Name).HasMaxLength(25).IsRequired(true);
        builder.Property(e => e.StreetAddress1).HasMaxLength(100).IsRequired(true);
        builder.Property(e => e.StreetAddress2).HasMaxLength(100);
        builder.Property(e => e.City).HasMaxLength(15).IsRequired(true);
        builder.Property(e => e.ZipCode).HasMaxLength(10).IsRequired(true);
        builder.Property(e => e.StateId).IsRequired(true);
        builder.Property(e => e.CellPhone).HasMaxLength(10);
        builder.Property(e => e.WorkPhone).HasMaxLength(10);

        builder.HasOne<State>()
            .WithMany()
            .HasForeignKey(e => e.StateId);
    }
}
