using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class PetBreedEntity : Entity
{
    public int PetTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual PetTypeEntity PetType { get; set; } = null!;

    public virtual ICollection<PetEntity> Pets { get; } = new List<PetEntity>();
}
