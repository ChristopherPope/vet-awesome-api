#nullable disable
using VetAwesome.Domain.Addresses;
using VetAwesome.Domain.Interfaces;

namespace VetAwesome.Domain.States;

public partial class State : IEntity
{
    public int Id { get; set; }

    public string Abbreviation { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}