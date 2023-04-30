namespace VetAwesome.Domain.Entities;

public sealed class Pet : Entity
{
    private List<Appointment> appointments = new();

    public IReadOnlyCollection<Appointment> Appointments => appointments;
    public int CustomerId { get; private set; }
    public int PetBreedId { get; private set; }
    public string Name { get; private set; } = null!;
    public Customer Customer { get; private set; } = null!;
    public PetBreed PetBreed { get; private set; } = null!;

    private Pet()
    {
    }

    private Pet(string name, PetBreed breed, Customer owner)
    {
        Name = name;
        PetBreedId = breed.Id;
        PetBreed = breed;
        Customer = owner;
        CustomerId = owner.Id;
    }

    static internal Pet Create(string name, PetBreed breed, Customer owner)
    {
        return new Pet(name, breed, owner);
    }
}
