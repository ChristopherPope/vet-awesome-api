using VetAwesome.Domain.Entities;

namespace VetAwesome.Domain.Repositories;

public interface ICustomerRepository
{
    void Create(Customer customer);
}
