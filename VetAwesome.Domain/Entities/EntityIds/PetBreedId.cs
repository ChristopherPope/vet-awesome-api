namespace VetAwesome.Domain.Entities.EntityIds;

public record PetBreedId : BaseEntityId
{
    public PetBreedId(int id)
        : base(id)
    {
    }

    public static implicit operator PetBreedId(int v)
    {
        return new PetBreedId(v);
    }
}
