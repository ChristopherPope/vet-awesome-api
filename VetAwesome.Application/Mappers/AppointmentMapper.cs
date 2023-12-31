using Riok.Mapperly.Abstractions;
using VetAwesome.Application.Appointments.Queries;
using VetAwesome.Application.Mappers.Interfaces;
using VetAwesome.Domain.Appointments;

namespace VetAwesome.Application.Mappers;

[Mapper]
internal partial class AppointmentMapper : IAppointmentMapper
{
    public partial IEnumerable<AppointmentDto> FromEntities(IEnumerable<Appointment> entities);

    public AppointmentDto FromEntity(Appointment entity)
    {
        var dto = InternalFromEntity(entity);
        if (entity.Veterinarian != null)
        {
            var firstInitial = entity.Veterinarian.FirstName[0].ToString().ToUpper();
            dto.VeterinarianName = $"Dr. {firstInitial}. {entity.Veterinarian.LastName}";
        }

        return dto;
    }

    private partial AppointmentDto InternalFromEntity(Appointment entity);
}
