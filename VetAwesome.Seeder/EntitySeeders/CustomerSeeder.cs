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
    private readonly ILogger<PetBreedSeeder> logger;
    private readonly IUnitOfWork unitOfWork;
    private readonly ICustomerRepository customerRepo;
    private readonly IStateSeeder stateSeeder;
    private readonly Random rand = new Random();

    public IReadOnlyCollection<Customer> Customers => Entities;

    public CustomerSeeder(ILogger<PetBreedSeeder> logger, IUnitOfWork unitOfWork, ICustomerRepository customerRepo, IStateSeeder stateSeeder)
    {
        this.logger = logger;
        this.unitOfWork = unitOfWork;
        this.customerRepo = customerRepo;
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
                faker.PickRandom<State>(stateSeeder.States).Id,
                faker.Phone.PhoneNumber("(###) ###-####")
                );

            entities.Add(customer);
        }

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        await customerRepo.CreateRangeAsync(entities, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        logger.LogInformation($"Created {entities.Count:N0} customers.");
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await customerRepo.DeleteAllAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Deleted all customers.");
        entities = null;
    }
}
