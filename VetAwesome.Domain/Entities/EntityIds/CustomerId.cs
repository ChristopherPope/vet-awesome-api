namespace VetAwesome.Domain.Entities.EntityIds;

public record CustomerId : EntityId
{
    public CustomerId(int id)
        : base(id)
    {
    }

    public static implicit operator CustomerId(int v)
    {
        return new CustomerId(v);
    }
}
