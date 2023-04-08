using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class AppointmentEntity : Entity
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int PetId { get; set; }

    public int VeterinarianId { get; set; }

    public virtual PetEntity Pet { get; set; } = null!;

    public virtual UserEntity Veterinarian { get; set; } = null!;
}
