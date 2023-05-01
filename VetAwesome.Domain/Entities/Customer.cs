namespace VetAwesome.Domain.Entities;

public sealed class Customer : Entity
{
    private readonly List<Pet> pets = new();

    public IReadOnlyCollection<Pet> Pets => pets;

    private Customer(string name, string streetAddress, string city, string zip, State state, string phone)
    {
        Name = name;
        StreetAddress = streetAddress;
        City = city;
        ZipCode = zip;
        StateId = state.Id;
        State = state;
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

    public static Customer Create(string name, string streetAddress, string city, string zip, State state, string phone)
    {
        return new(name, streetAddress, city, zip, state, phone);
    }

    public Pet AddPet(string petName, PetBreed breed)
    {
        var pet = Pet.Create(petName, breed, this);
        pets.Add(pet);

        return pet;
    }
}
