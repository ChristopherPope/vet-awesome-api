namespace VetAwesome.Domain.Entities;

public sealed class Customer : Entity
{
    private readonly List<Pet> pets = new();

    private Customer(string name, string streetAddress, string city, string zip, int stateId, string phone)
    {
        Name = name;
        StreetAddress = streetAddress;
        City = city;
        ZipCode = zip;
        StateId = stateId;
        Phone = phone;
    }

    private Customer()
    {
    }

    public string Name { get; private set; } = null!;
    public string StreetAddress { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    public int StateId { get; private set; }
    public string Phone { get; private set; } = null!;

    public State State { get; private set; } = null!;
    public IReadOnlyCollection<Pet> Pets => pets;

    public static Customer Create(string name, string streetAddress, string city, string zip, int stateId, string phone)
    {
        return new(name, streetAddress, city, zip, stateId, phone);
    }
}
