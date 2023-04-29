using System;
using System.Collections.Generic;

namespace VetAwesome.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserRoleId { get; set; }

        public virtual Role UserRole { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
