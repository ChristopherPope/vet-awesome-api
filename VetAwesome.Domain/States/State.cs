#nullable disable
using VetAwesome.Domain.Addresses;

namespace VetAwesome.Domain.States;

public partial class State
{
    public int Id { get; set; }

    public string Abbreviation { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}