using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class RoleEntity : Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<UserEntity> Users { get; } = new List<UserEntity>();
}
