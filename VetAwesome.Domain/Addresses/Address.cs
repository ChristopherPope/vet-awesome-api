#nullable disable
using VetAwesome.Domain.Customers;
using VetAwesome.Domain.States;

namespace VetAwesome.Domain.Addresses;

public partial class Address
{
    public int Id { get; set; }

    public string StreetAddress { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public int StateId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual State State { get; set; }
}