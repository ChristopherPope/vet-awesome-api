namespace VetAwesome.Domain.Entities;

public sealed class PetBreed : Entity
{
    private List<Pet> pets = new();

    public IReadOnlyCollection<Pet> Pets => pets;
    public int PetTypeId { get; set; }
    public string Name { get; set; } = null!;
    public PetType PetType { get; set; } = null!;

    private PetBreed()
    {
    }

    private PetBreed(string name, PetType petType)
    {
        Name = name;
        PetType = petType;
        PetTypeId = petType.Id;
    }

    static internal PetBreed Create(string breedName, PetType petType)
    {
        return new PetBreed(breedName, petType);
    }
}
