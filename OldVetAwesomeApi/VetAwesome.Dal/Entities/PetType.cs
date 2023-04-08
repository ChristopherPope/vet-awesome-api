using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class PetTypeEntity : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<PetBreedEntity> PetBreeds { get; } = new List<PetBreedEntity>();
}
