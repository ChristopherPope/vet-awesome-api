using System;
using System.Collections.Generic;

namespace VetAwesome.Domain.Entities
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PetId { get; set; }
        public int VeterinarianId { get; set; }

        public virtual Pet Pet { get; set; } = null!;
        public virtual User Veterinarian { get; set; } = null!;
    }
}
