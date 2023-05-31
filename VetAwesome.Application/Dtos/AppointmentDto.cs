namespace VetAwesome.Application.Dtos;

public sealed class AppointmentDto
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public int PetBreedId { get; set; }
    public int PetTypeId { get; set; }
    public int VeterinarianId { get; private set; }

    public string? PetBreed { get; set; }
    public string? VetName { get; set; }
    public string? OwnerName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int DurationMins { get; set; }

    public CustomerDto? Owner { get; set; }
}

