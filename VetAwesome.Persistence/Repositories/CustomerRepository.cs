using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;

namespace VetAwesome.Persistence.Repositories;

internal sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(VetAwesomeDb dbContext)
        : base(dbContext)
    {
    }

    public void Create(Customer customer)
    {
        entities.Add(customer);
    }
}
