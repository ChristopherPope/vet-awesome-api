namespace VetAwesome.Domain.Entities;

public sealed class Role : Entity
{
    private readonly List<User> users = new();

    public string Name { get; private set; } = null!;
    public IReadOnlyCollection<User> Users => users;

    private Role()
    {
    }

    public Role(int id, string name)
        : base(id)
    {
        Name = name;
    }

    static public Role Create(int id, string name)
    {
        return new Role(id, name);
    }

}
