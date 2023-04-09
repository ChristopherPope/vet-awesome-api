namespace VetAwesome.Domain.Entities.EntityIds;

public record PetTypeId : BaseEntityId
{
    public PetTypeId(int id)
        : base(id)
    {
    }

    public static implicit operator PetTypeId(int v)
    {
        return new PetTypeId(v);
    }
}
