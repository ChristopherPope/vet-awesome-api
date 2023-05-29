using VetAwesome.Application.Interfaces.Persistence;
using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Infrastructure.Persistence.Repositories;

namespace VetAwesome.Infrastructure.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly VetAwesomeDb dbContext;

    public IAppointmentRepository Appointments { get; private set; }
    public ICustomerRepository Customers { get; private set; }
    public IPetBreedRepository Breeds { get; private set; }
    public IPetTypeRepository PetTypes { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public IStateRepository States { get; private set; }
    public IUserRepository Users { get; private set; }
    public IPetRepository Pets { get; private set; }

    public UnitOfWork(VetAwesomeDb dbContext)
    {
        this.dbContext = dbContext;
        Appointments = new AppointmentRepository(dbContext);
        Customers = new CustomerRepository(dbContext);
        Breeds = new PetBreedRepository(dbContext);
        PetTypes = new PetTypeRepository(dbContext);
        Roles = new RoleRepository(dbContext);
        States = new StateRepository(dbContext);
        Users = new UserRepository(dbContext);
        Pets = new PetRepository(dbContext);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
