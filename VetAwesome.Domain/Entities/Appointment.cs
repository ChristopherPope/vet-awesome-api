namespace VetAwesome.Domain.Entities;

public sealed class Appointment : Entity
{
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public int PetId { get; private set; }
    public int VeterinarianId { get; private set; }
    public Pet Pet { get; private set; } = null!;
    public User Veterinarian { get; private set; } = null!;

    private Appointment()
    {
    }

    private Appointment(DateTime startTime, DateTime endTime, Pet pet, User vet)
    {
        StartTime = startTime;
        EndTime = endTime;
        PetId = pet.Id;
        Pet = pet;

        Veterinarian = vet;
        VeterinarianId = vet.Id;
    }

    static internal Appointment Create(DateTime startTime, DateTime endTime, Pet pet, User vet)
    {
        return new Appointment(startTime, endTime, pet, vet);
    }
}
