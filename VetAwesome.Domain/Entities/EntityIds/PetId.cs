﻿namespace VetAwesome.Domain.Entities.EntityIds;

public record PetId : BaseEntityId
{
    public PetId(int id)
        : base(id)
    {
    }

    public static implicit operator PetId(int v)
    {
        return new PetId(v);
    }
}