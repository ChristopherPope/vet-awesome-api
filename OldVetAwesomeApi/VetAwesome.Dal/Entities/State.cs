using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class StateEntity : Entity
{
    public string Abbreviation { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CustomerEntity> Customers { get; } = new List<CustomerEntity>();
}
