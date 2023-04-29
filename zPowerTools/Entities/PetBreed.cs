using System;
using System.Collections.Generic;

namespace VetAwesome.Domain.Entities
{
    public partial class PetBreed
    {
        public PetBreed()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public int PetTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual PetType PetType { get; set; } = null!;
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
