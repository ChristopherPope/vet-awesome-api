using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IPetTypeSeeder : IEntitySeeder
{
    IReadOnlyCollection<PetType> PetTypes { get; }
}
