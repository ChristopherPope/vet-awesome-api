﻿using VetAwesome.Domain.Entities.EntityIds;
using VetAwesome.Domain.Primitives;

namespace VetAwesome.Domain.Entities;

public sealed class PetBreed : Entity<PetBreedId>
{
    public PetBreed()
        : base(0)
    {
    }

    public string Name { get; private set; } = string.Empty;
    public PetTypeId PetTypeId = 0;
}