namespace VetAwesome.Domain.Entities;

public sealed class Pet : Entity
{
    internal Pet(int id)
        : base(id)
    {
        Appointments = new HashSet<Appointment>();
    }

    public int CustomerId { get; set; }
    public int PetBreedId { get; set; }
    public string Name { get; set; } = null!;

    public Customer Customer { get; set; } = null!;
    public PetBreed PetBreed { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; }
}
