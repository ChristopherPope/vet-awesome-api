using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class UserEntity : Entity
{
    public string Name { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<AppointmentEntity> Appointments { get; } = new List<AppointmentEntity>();

    public virtual RoleEntity Role { get; set; } = null!;
}
