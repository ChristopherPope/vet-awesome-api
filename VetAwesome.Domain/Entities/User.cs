namespace VetAwesome.Domain.Entities;

public sealed class User : Entity
{
    internal User(int id)
        : base(id)
    {
        Appointments = new HashSet<Appointment>();
    }

    public string Name { get; set; } = null!;
    public int UserRoleId { get; set; }

    public Role UserRole { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; }
}
