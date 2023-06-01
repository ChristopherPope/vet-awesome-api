using AutoMapper;
using VetAwesome.Application.Dtos;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.EntityDtoMapping;

internal sealed class AppointmentMapping : Profile
{
    public AppointmentMapping()
    {
        CreateMap<Appointment, AppointmentDto>()
            .ForMember(dto => dto.PetBreed, opt => opt.MapFrom(entity => $"{entity.Pet.PetBreed.PetType.Name} - {entity.Pet.PetBreed.Name}"))
            .ForMember(dto => dto.Owner, opt => opt.MapFrom(entity => entity.Pet.Customer))
            .ForMember(dto => dto.OwnerName, opt => opt.MapFrom(entity => entity.Pet.Customer.Name))
            .ForMember(dto => dto.VetName, opt => opt.MapFrom(entity => entity.Veterinarian.Name))
            .ForMember(dto => dto.PetBreedId, opt => opt.MapFrom(entity => entity.Pet.PetBreedId))
            .ForMember(dto => dto.PetTypeId, opt => opt.MapFrom(entity => entity.Pet.PetBreed.PetTypeId))
            .ForMember(dto => dto.DurationMins, opt => opt.MapFrom(entity => (entity.EndTime - entity.StartTime).Minutes));


        CreateMap<Customer, CustomerDto>();
        CreateMap<Pet, PetDto>();
        CreateMap<PetType, PetTypeDto>();
        CreateMap<PetBreed, PetBreedDto>();
        CreateMap<Role, UserRoleDto>();
        CreateMap<State, StateDto>();
    }
}
