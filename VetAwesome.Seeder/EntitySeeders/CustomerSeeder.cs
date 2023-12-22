using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.Database;
using VetAwesome.Seeder.EntitySeeders.Interfaces;
using static Bogus.DataSets.Name;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class CustomerSeeder : EntitySeeder<Customer>, ICustomerSeeder
{
    private readonly ILogger<CustomerSeeder> logger;
    private readonly IAddressSeeder addressSeeder;

    public IReadOnlyCollection<Customer> Customers => EntityList;

    public CustomerSeeder(ILogger<CustomerSeeder> logger
        , VetAwesomeDb vetDb
        , IAddressSeeder addressSeeder)
        : base(logger, vetDb)
    {
        this.logger = logger;
        this.addressSeeder = addressSeeder;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = [];
        while (entityList.Count < addressSeeder.Addresses.Count)
        {
            var customer = new Customer
            {
                FirstName = faker.Name.FirstName(faker.PickRandom<Gender>()),
                LastName = faker.Name.LastName(),
                CellPhone = faker.Phone.PhoneNumber("##########"),
                WorkPhone = faker.Phone.PhoneNumber("########## x###"),
                Address = addressSeeder.Addresses.ElementAt(entityList.Count)
            };

            entityList.Add(customer);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
