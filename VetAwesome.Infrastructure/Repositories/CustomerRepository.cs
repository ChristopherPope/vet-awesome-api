using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Repositories;

internal sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.Customers)
    {
    }
}
