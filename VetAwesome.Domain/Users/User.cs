#nullable disable
using VetAwesome.Domain.Appointments;
using VetAwesome.Domain.UserRoles;

namespace VetAwesome.Domain.Users;

public partial class User
{
    public int Id { get; set; }

    public int UserRoleId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual UserRole UserRole { get; set; }
}