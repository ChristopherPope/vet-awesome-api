using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IPetSeeder : IEntitySeeder
{
    IReadOnlyCollection<Pet> Pets { get; }
    Task LoadAllPetsAsync(CancellationToken cancellationToken);
}
