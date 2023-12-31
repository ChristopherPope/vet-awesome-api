namespace VetAwesome.Application.Appointments.Queries;
public record AppointmentDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string VeterinarianName { get; set; } = null!;
}
