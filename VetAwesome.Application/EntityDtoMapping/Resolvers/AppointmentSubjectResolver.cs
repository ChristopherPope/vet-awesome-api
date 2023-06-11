using AutoMapper;
using VetAwesome.Application.Dtos;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.EntityDtoMapping.Resolvers;

internal sealed class AppointmentSubjectResolver : IValueResolver<Appointment, AppointmentDto, string>
{
    public string Resolve(Appointment source, AppointmentDto destination, string destMember, ResolutionContext context)
    {
        return $"{source.Pet.Customer.Name} - {source.Pet.Name}";
    }
}
