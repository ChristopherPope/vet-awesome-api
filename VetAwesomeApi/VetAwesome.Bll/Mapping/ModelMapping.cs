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
            CreateMap<Household, HouseholdEntity>();
            CreateMap<PetType, PetTypeEntity>();
            CreateMap<PetBreed, PetBreedEntity>();
            CreateMap<Pet, PetEntity>();
            CreateMap<User, UserEntity>();
            CreateMap<Role, RoleEntity>();
            CreateMap<State, StateEntity>();
        }

        private void CreateProjections()
        {
            CreateProjection<RoleEntity, Role>();
            CreateProjection<AppointmentEntity, Appointment>();
            CreateProjection<CustomerEntity, Customer>();
            CreateProjection<HouseholdEntity, Household>();
            CreateProjection<PetTypeEntity, PetType>();
            CreateProjection<PetBreedEntity, PetBreed>();
            CreateProjection<PetEntity, Pet>();
            CreateProjection<UserEntity, User>();
            CreateProjection<StateEntity, State>();
        }
    }
}
