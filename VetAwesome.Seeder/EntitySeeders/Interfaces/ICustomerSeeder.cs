using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface ICustomerSeeder : IEntitySeeder
{
    IReadOnlyCollection<Customer> Customers { get; }
}
