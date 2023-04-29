using System;
using System.Collections.Generic;

namespace VetAwesome.Domain.Entities
{
    public partial class Pet
    {
        public Pet()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PetBreedId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual PetBreed PetBreed { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
