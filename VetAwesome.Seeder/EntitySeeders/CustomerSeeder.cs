using Bogus;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Persistence;
using VetAwesome.Seeder.EntitySeeders.Interfaces;
using static Bogus.DataSets.Name;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class CustomerSeeder : EntitySeeder<Customer>, ICustomerSeeder
{
    private readonly ILogger<CustomerSeeder> logger;
    private readonly IStateSeeder stateSeeder;

    public IReadOnlyCollection<Customer> Customers => EntityList;

    public CustomerSeeder(ILogger<CustomerSeeder> logger
        , VetAwesomeDb vetDb
        , IStateSeeder stateSeeder)
        : base(logger, vetDb)
    {
        this.logger = logger;
        this.stateSeeder = stateSeeder;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = new List<Customer>();
        var customerCount = rand.Next(10, 51);
        var faker = new Faker();
        while (entityList.Count < customerCount)
        {
            var gender = faker.PickRandom<Gender>();
            var customer = Customer.Create(
                $"{faker.Name.FirstName(gender)} {faker.Name.LastName()}",
                faker.Address.StreetAddress(),
                faker.Address.City(),
                faker.Address.ZipCode(),
                faker.PickRandom<State>(stateSeeder.States),
                faker.Phone.PhoneNumber("(###) ###-####")
                );

            entityList.Add(customer);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
