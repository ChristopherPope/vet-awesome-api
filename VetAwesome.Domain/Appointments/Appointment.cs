#nullable disable
using VetAwesome.Domain.Pets;
using VetAwesome.Domain.Users;

namespace VetAwesome.Domain.Appointments;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int PetId { get; set; }

    public int VeterinarianId { get; set; }

    public virtual Pet Pet { get; set; }

    public virtual User Veterinarian { get; set; }
}