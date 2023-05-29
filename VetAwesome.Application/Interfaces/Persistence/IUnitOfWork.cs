using VetAwesome.Application.Interfaces.Persistence.Repositories;

namespace VetAwesome.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    IAppointmentRepository Appointments { get; }
    ICustomerRepository Customers { get; }
    IPetBreedRepository Breeds { get; }
    IPetTypeRepository PetTypes { get; }
    IPetRepository Pets { get; }
    IRoleRepository Roles { get; }
    IStateRepository States { get; }
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
