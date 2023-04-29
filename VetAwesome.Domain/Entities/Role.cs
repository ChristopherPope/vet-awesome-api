namespace VetAwesome.Domain.Entities;

public sealed class Role : Entity
{
    internal Role(int id)
        : base(id)
    {
        Users = new HashSet<User>();
    }

    public string Name { get; set; } = null!;

    public ICollection<User> Users { get; set; }
}
