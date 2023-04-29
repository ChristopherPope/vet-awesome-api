using System;
using System.Collections.Generic;

namespace VetAwesome.Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string StreetAddress1 { get; set; } = null!;
        public string? StreetAddress2 { get; set; }
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public int StateId { get; set; }
        public string? CellPhone { get; set; }
        public string? HomePhone { get; set; }
        public string? WorkPhone { get; set; }

        public virtual State State { get; set; } = null!;
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
