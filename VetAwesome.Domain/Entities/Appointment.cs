namespace VetAwesome.Domain.Entities;

public sealed class Appointment : Entity
{
    internal Appointment(int id)
        : base(id)
    {
    }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int PetId { get; set; }
    public int VeterinarianId { get; set; }

    public Pet Pet { get; set; } = null!;
    public User Veterinarian { get; set; } = null!;
}
