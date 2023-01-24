using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class CustomerEntity : Entity
{
    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int HouseholdId { get; set; }

    public virtual ICollection<AppointmentEntity> Appointments { get; } = new List<AppointmentEntity>();

    public virtual HouseholdEntity Household { get; set; } = null!;
}
