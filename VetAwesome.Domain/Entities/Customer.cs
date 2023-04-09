using VetAwesome.Domain.Entities.EntityIds;
using VetAwesome.Domain.Primitives;

namespace VetAwesome.Domain.Entities;

public sealed class Customer : Entity<CustomerId>
{
    public Customer()
        : base(0)
    {
    }

    public string Name { get; private set; } = string.Empty;

    public string StreetAddress1 { get; private set; } = string.Empty;

    public string? StreetAddress2 { get; private set; }

    public string City { get; private set; } = string.Empty;

    public string ZipCode { get; private set; } = string.Empty;

    public StateId StateId { get; private set; } = 0;

    public string? CellPhone { get; private set; }

    public string? HomePhone { get; private set; }

    public string? WorkPhone { get; private set; }
}