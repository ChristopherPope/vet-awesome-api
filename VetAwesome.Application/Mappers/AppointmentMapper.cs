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
        var firstInitial = entity.Veterinarian.FirstName[0].ToString().ToUpper();
        dto.VeterinarianName = $"Dr. {firstInitial}. {entity.Veterinarian.LastName}";

        dto.CustomerName = $"{entity.Pet.Customer.FirstName} {entity.Pet.Customer.LastName}";

        return dto;
    }

    [MapProperty(nameof(@Appointment.Pet.PetBreed.Name), nameof(AppointmentDto.Breed))]
    [MapProperty(nameof(@Appointment.Pet.PetBreed.PetType.Name), nameof(AppointmentDto.PetType))]
    private partial AppointmentDto InternalFromEntity(Appointment entity);
}
