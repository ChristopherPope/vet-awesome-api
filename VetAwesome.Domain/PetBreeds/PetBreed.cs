#nullable disable
using VetAwesome.Domain.Pets;
using VetAwesome.Domain.PetTypes;

namespace VetAwesome.Domain.PetBreeds;

public partial class PetBreed
{
    public int Id { get; set; }

    public int PetTypeId { get; set; }

    public string Name { get; set; }

    public virtual PetType PetType { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}