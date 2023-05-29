using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.Customers)
    {
    }
}
