using VetAwesome.Application.Appointments.Queries;
using VetAwesome.Domain.Appointments;

namespace VetAwesome.Application.Mappers.Interfaces;
internal interface IAppointmentMapper
{
    AppointmentDto FromEntity(Appointment entity);
    IEnumerable<AppointmentDto> FromEntities(IEnumerable<Appointment> entities);
}
