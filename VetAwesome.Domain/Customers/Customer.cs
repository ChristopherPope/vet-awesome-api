#nullable disable
using VetAwesome.Domain.Addresses;
using VetAwesome.Domain.Pets;

namespace VetAwesome.Domain.Customers;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string CellPhone { get; set; }

    public string WorkPhone { get; set; }

    public string OtherPhone { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}