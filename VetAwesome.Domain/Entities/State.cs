using VetAwesome.Domain.Entities.EntityIds;
using VetAwesome.Domain.Primitives;

namespace VetAwesome.Domain.Entities;

public sealed class State : Entity<StateId>
{
    public State()
        : base(0)
    {
    }

    public string Name { get; private set; } = string.Empty;
}