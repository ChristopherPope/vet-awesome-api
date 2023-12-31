namespace VetAwesome.Application.Appointments.Queries;
public record AppointmentDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string VeterinarianName { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string PetName { get; set; } = null!;
    public string PetType { get; set; } = null!;
    public string Breed { get; set; } = null!;
}
