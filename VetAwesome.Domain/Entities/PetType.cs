namespace VetAwesome.Domain.Entities;

public sealed class PetType : Entity
{
    private readonly List<PetBreed> petBreeds = new();

    public IReadOnlyCollection<PetBreed> PetBreeds => petBreeds;

    private PetType()
    {
    }

    private PetType(int id, string name)
        : base(id)
    {
        Name = name;
    }

    static public PetType Create(string name)
    {
        return new PetType(0, name);
    }

    public PetBreed AddBreed(string breedName)
    {
        var breed = PetBreed.Create(breedName, this);
        petBreeds.Add(breed);

        return breed;
    }

    public string Name { get; private set; } = null!;
}
