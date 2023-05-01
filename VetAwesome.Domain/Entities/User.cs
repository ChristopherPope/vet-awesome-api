namespace VetAwesome.Domain.Entities;

public sealed class User : Entity
{
    private List<Appointment> appointments = new();

    public IReadOnlyCollection<Appointment> Appointments => appointments;
    public string Name { get; private set; } = null!;
    public int UserRoleId { get; private set; }
    public Role UserRole { get; private set; } = null!;

    private User()
    {
    }

    private User(string name, Role role)
    {
        Name = name;
        UserRoleId = role.Id;
        UserRole = role;
    }

    static public User Create(string name, Role role)
    {
        return new User(name, role);
    }
}
