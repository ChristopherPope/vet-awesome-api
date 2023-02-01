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
            CreateProjection<AppointmentEntity, Appointment>();
            CreateProjection<CustomerEntity, Customer>();
            CreateProjection<PetTypeEntity, PetType>();
            CreateProjection<PetBreedEntity, PetBreed>();
            CreateProjection<PetEntity, Pet>();
            CreateProjection<UserEntity, User>();
            CreateProjection<StateEntity, State>();
        }
    }
}
