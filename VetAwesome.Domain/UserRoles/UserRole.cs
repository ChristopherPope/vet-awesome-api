#nullable disable
using VetAwesome.Domain.Interfaces;
using VetAwesome.Domain.Users;

namespace VetAwesome.Domain.UserRoles;

public partial class UserRole : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}