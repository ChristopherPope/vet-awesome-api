namespace VetAwesome.Domain.Entities;

public sealed class PetType : Entity
{
    private readonly List<PetBreed> breeds = new();

    public IReadOnlyCollection<PetBreed> Breeds => breeds;
    public string Name { get; private set; } = null!;

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
        breeds.Add(breed);

        return breed;
    }
}
