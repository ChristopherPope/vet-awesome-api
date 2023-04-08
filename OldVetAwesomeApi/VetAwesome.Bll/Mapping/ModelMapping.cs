using AutoMapper;
using VetAwesome.Bll.Dtos;
using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.Mapping
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMaps();
            CreateProjections();
        }

        private void CreateMaps()
        {
            CreateMap<Appointment, AppointmentEntity>();
            CreateMap<Customer, CustomerEntity>();
            CreateMap<PetType, PetTypeEntity>();
            CreateMap<PetBreed, PetBreedEntity>();
            CreateMap<Pet, PetEntity>();
            CreateMap<User, UserEntity>();
            CreateMap<UserRole, UserRoleEntity>();
            CreateMap<State, StateEntity>();
        }

        private void CreateProjections()
        {
            CreateProjection<UserRoleEntity, UserRole>();
            CreateProjection<CustomerEntity, Customer>();
            CreateProjection<PetTypeEntity, PetType>();
            CreateProjection<PetBreedEntity, PetBreed>();
            CreateProjection<PetEntity, Pet>();
            CreateProjection<StateEntity, State>();

            CreateProjection<UserEntity, User>()
                .ForMember(dest => dest.RoleId, cfg => cfg.MapFrom(src => src.UserRoleId));

            CreateProjection<AppointmentEntity, Appointment>()
                .ForMember(dest => dest.Veterinarian, cfg => cfg.MapFrom(src => src.Veterinarian.Name))
                .ForMember(dest => dest.VeterinarianId, cfg => cfg.MapFrom(src => src.Veterinarian.Id))
                .ForMember(dest => dest.CustomerName, cfg => cfg.MapFrom(src => src.Pet.Customer.Name))
                .ForMember(dest => dest.StreetAddress1, cfg => cfg.MapFrom(src => src.Pet.Customer.StreetAddress1))
                .ForMember(dest => dest.StreetAddress2, cfg => cfg.MapFrom(src => src.Pet.Customer.StreetAddress2))
                .ForMember(dest => dest.City, cfg => cfg.MapFrom(src => src.Pet.Customer.City))
                .ForMember(dest => dest.ZipCode, cfg => cfg.MapFrom(src => src.Pet.Customer.ZipCode))
                .ForMember(dest => dest.StateId, cfg => cfg.MapFrom(src => src.Pet.Customer.State.Id))
                .ForMember(dest => dest.StateName, cfg => cfg.MapFrom(src => src.Pet.Customer.State.Name))
                .ForMember(dest => dest.StateAbbreviation, cfg => cfg.MapFrom(src => src.Pet.Customer.State.Abbreviation))
                .ForMember(dest => dest.PetName, cfg => cfg.MapFrom(src => src.Pet.Name))
                .ForMember(dest => dest.PetType, cfg => cfg.MapFrom(src => src.Pet.PetBreed.PetType.Name))
                .ForMember(dest => dest.PetTypeId, cfg => cfg.MapFrom(src => src.Pet.PetBreed.PetType.Id))
                .ForMember(dest => dest.PetBreed, cfg => cfg.MapFrom(src => src.Pet.PetBreed.Name))
                .ForMember(dest => dest.PetBreedId, cfg => cfg.MapFrom(src => src.Pet.PetBreed.Id))
                .ForMember(dest => dest.HomePhone, cfg => cfg.MapFrom(src => src.Pet.Customer.HomePhone))
                .ForMember(dest => dest.WorkPhone, cfg => cfg.MapFrom(src => src.Pet.Customer.WorkPhone))
                .ForMember(dest => dest.CellPhone, cfg => cfg.MapFrom(src => src.Pet.Customer.CellPhone))
                .ForMember(dest => dest.CustomerId, cfg => cfg.MapFrom(src => src.Pet.Customer.Id));
        }
    }
}
