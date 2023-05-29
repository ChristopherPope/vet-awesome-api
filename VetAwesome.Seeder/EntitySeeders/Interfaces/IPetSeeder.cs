using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IPetSeeder : IEntitySeeder
{
    IReadOnlyCollection<Pet> Pets { get; }
    Task LoadAllPetsAsync(CancellationToken cancellationToken);
}
