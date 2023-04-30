namespace VetAwesome.Domain.Entities;

public sealed class State : Entity
{
    private readonly List<Customer> customers = new();

    public string Abbreviation { get; private set; } = null!;
    public string Name { get; private set; } = null!;

    public IReadOnlyCollection<Customer> Customers => customers;

    private State()
    {
    }

    private State(string abbreviation, string name)
    {
        Abbreviation = abbreviation;
        Name = name;
    }

    static public State Create(string abbreviation, string name)
    {
        return new State(abbreviation, name);
    }
}
