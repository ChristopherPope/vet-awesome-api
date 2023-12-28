#nullable disable
using VetAwesome.Domain.Interfaces;
using VetAwesome.Domain.PetBreeds;

namespace VetAwesome.Domain.PetTypes;

public partial class PetType : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<PetBreed> PetBreeds { get; set; } = new List<PetBreed>();
}