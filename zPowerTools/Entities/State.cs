using System;
using System.Collections.Generic;

namespace VetAwesome.Domain.Entities
{
    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Abbreviation { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
