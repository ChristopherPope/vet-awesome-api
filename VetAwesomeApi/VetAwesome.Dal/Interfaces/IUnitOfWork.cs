using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStatesRepository States { get; }
        IUserRepository Users { get; }
        ICustomerRepository Customers { get; }
        IPetBreedRepository PetBreeds { get; }
        IPetRepository Pets { get; }
        IUserRoleRepository UserRoles { get; }
        IPetTypeRepository PetTypes { get; }
        IAppointmentRepository Appointments { get; }

        int Commit();
    }
}
