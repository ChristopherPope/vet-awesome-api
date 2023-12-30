namespace VetAwesome.Application.Appointments.Queries;
public record AppointmentDto
{
    public DateTime AppointmentTime { get; set; }
    public string VeterinarianName { get; set; } = null!;
}
