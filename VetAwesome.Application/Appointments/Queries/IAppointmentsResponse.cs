using VetAwesome.Application.Interfaces;

namespace VetAwesome.Application.Appointments.Queries;
public interface IAppointmentsResponse : IResponse
{
    IEnumerable<AppointmentDto>? Appointments { get; }
}
