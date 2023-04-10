using VetAwesome.Domain.Entities.EntityIds;
using VetAwesome.Domain.Primitives;

namespace VetAwesome.Domain.Entities;

public sealed class Customer : Entity<CustomerId>
{
    private Customer(
        string name,
        string streetAddress,
        string city,
        string zip,
        StateId stateId,
        string phone
        )
        : base(0)
    {
        Name = name;
        StreetAddress = streetAddress;
        City = city;
        ZipCode = zip;
        StateId = stateId;
        Phone = phone;
    }

    private Customer()
        : base(0)
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string StreetAddress { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string ZipCode { get; private set; } = string.Empty;
    public StateId StateId { get; private set; } = 0;
    public string Phone { get; private set; } = string.Empty;

    public static Customer Create(
        string name,
        string streetAddress,
        string city,
        string zip,
        StateId stateId,
        string phone
        )
    {
        return new Customer(name, streetAddress, city, zip, stateId, phone);
    }
}