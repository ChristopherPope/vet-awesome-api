using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class PetEntity : Entity
{
    public int CustomerId { get; set; }

    public int PetBreedId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AppointmentEntity> Appointments { get; } = new List<AppointmentEntity>();

    public virtual CustomerEntity Customer { get; set; } = null!;

    public virtual PetBreedEntity PetBreed { get; set; } = null!;
}
