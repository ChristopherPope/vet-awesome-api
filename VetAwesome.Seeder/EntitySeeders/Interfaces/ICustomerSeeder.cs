using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface ICustomerSeeder : IEntitySeeder
{
    IReadOnlyCollection<Customer> Customers { get; }
}
