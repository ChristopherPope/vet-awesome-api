using VetAwesome.Bll.Dtos;

namespace VetAwesome.Bll.Interfaces.Services
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> ReadAppointments(DateTime inclusiveStart, DateTime inclusiveEnd);
    }
}
