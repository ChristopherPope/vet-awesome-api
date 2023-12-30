using Riok.Mapperly.Abstractions;
using VetAwesome.Application.Appointments.Queries;
using VetAwesome.Application.Mappers.Interfaces;
using VetAwesome.Domain.Appointments;

namespace VetAwesome.Application.Mappers;

[Mapper]
internal partial class AppointmentMapper : IAppointmentMapper
{
    public partial IEnumerable<AppointmentDto> FromEntities(IEnumerable<Appointment> entities);

    public partial AppointmentDto FromEntity(Appointment entity);
}
