using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetAwesome.Domain.Customers;

namespace VetAwesome.Persistence.Configurations;

public partial class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.ToTable("Customer");

        entity.Property(e => e.CellPhone)
        .HasMaxLength(10)
        .IsUnicode(false);
        entity.Property(e => e.FirstName)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);
        entity.Property(e => e.LastName)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);
        entity.Property(e => e.OtherPhone)
        .HasMaxLength(20)
        .IsUnicode(false);
        entity.Property(e => e.WorkPhone)
        .HasMaxLength(20)
        .IsUnicode(false);

        entity.HasOne(d => d.Address).WithMany(p => p.Customers)
        .HasForeignKey(d => d.AddressId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Customer_Address");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Customer> entity);
}
