using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IPetTypeSeeder : IEntitySeeder
{
    IReadOnlyCollection<PetType> PetTypes { get; }
}
