namespace VetAwesome.Domain.Entities;

public sealed class PetBreed : Entity
{
    internal PetBreed(int id)
        : base(id)
    {
        Pets = new HashSet<Pet>();
    }

    public int PetTypeId { get; set; }
    public string Name { get; set; } = null!;

    public PetType PetType { get; set; } = null!;
    public ICollection<Pet> Pets { get; set; }
}
