using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.Database;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;
internal class AddressSeeder : EntitySeeder<Address>, IAddressSeeder
{
    private readonly IStateSeeder stateSeeder;
    private readonly ILogger<AddressSeeder> logger;
    private CancellationToken cancellationToken = default(CancellationToken);
    private readonly int numAddressesToCreate;

    public IReadOnlyCollection<Address> Addresses => EntityList;

    public AddressSeeder(ILogger<AddressSeeder> logger
    , VetAwesomeDb vetDb
    , IStateSeeder stateSeeder)
    : base(logger, vetDb)
    {
        this.stateSeeder = stateSeeder;
        this.logger = logger;
        numAddressesToCreate = rand.Next(10, 51);
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        this.cancellationToken = cancellationToken;
        var states = stateSeeder.States;

        entityList = [];
        for (int i = 0; i <= numAddressesToCreate; i++)
        {
            var fakeAddress = faker.Address;
            var address = new Address
            {
                StreetAddress = fakeAddress.StreetAddress(),
                City = fakeAddress.City(),
                ZipCode = fakeAddress.ZipCode(),
                State = faker.PickRandom<State>(states)
            };

            entityList.Add(address);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
