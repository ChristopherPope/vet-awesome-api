namespace VetAwesome.Domain.Entities;

public sealed class State : Entity
{
    internal State(int id)
        : base(id)
    {
        Customers = new HashSet<Customer>();
    }

    public string Abbreviation { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ICollection<Customer> Customers { get; set; }
}
