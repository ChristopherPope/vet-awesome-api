using Bogus;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Seeder.EntitySeeders.Interfaces;
using static Bogus.DataSets.Name;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class CustomerSeeder : EntitySeeder<Customer>, ICustomerSeeder
{
    private readonly ILogger<CustomerSeeder> logger;
    private readonly IStateSeeder stateSeeder;

    public IReadOnlyCollection<Customer> Customers => Entities;

    public CustomerSeeder(ILogger<CustomerSeeder> logger, IUnitOfWork unitOfWork, ICustomerRepository customerRepo, IStateSeeder stateSeeder)
        : base(unitOfWork, customerRepo, logger)
    {
        this.logger = logger;
        this.stateSeeder = stateSeeder;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        entities = new List<Customer>();
        var customerCount = rand.Next(10, 51);
        var faker = new Faker();
        while (entities.Count < customerCount)
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

            entities.Add(customer);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
