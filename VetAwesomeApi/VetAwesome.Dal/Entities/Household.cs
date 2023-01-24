using System;
using System.Collections.Generic;

namespace VetAwesome.Dal.Entities;

public partial class HouseholdEntity : Entity
{
    public string StreetAddress1 { get; set; } = null!;

    public string? StreetAddress2 { get; set; }

    public string ZipCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public int StateId { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<CustomerEntity> Customers { get; } = new List<CustomerEntity>();

    public virtual ICollection<PetEntity> Pets { get; } = new List<PetEntity>();

    public virtual StateEntity State { get; set; } = null!;
}
