using VetAwesome.Domain.Entities.EntityIds;
using VetAwesome.Domain.Primitives;

namespace VetAwesome.Domain.Entities;

public sealed class Pet : Entity<PetId>
{
    public Pet()
        : base(0)
    {
    }

    public string Name { get; private set; } = string.Empty;
    public PetBreedId BreedId { get; private set; } = 0;
    public CustomerId OwnerId { get; private set; } = 0;
}