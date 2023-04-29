using System;
using System.Collections.Generic;

namespace VetAwesome.Domain.Entities
{
    public partial class PetType
    {
        public PetType()
        {
            PetBreeds = new HashSet<PetBreed>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PetBreed> PetBreeds { get; set; }
    }
}
