namespace VetAwesome.Domain.Entities;

public sealed class PetType : Entity
{
    internal PetType(int id)
        : base(id)
    {
        PetBreeds = new HashSet<PetBreed>();
    }

    public string Name { get; set; } = null!;

    public ICollection<PetBreed> PetBreeds { get; set; }
}
