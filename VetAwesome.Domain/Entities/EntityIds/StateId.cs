namespace VetAwesome.Domain.Entities.EntityIds;

public record StateId : EntityId
{
    public StateId(int id)
        : base(id)
    {
    }

    public static implicit operator StateId(int v)
    {
        return new StateId(v);
    }
}
