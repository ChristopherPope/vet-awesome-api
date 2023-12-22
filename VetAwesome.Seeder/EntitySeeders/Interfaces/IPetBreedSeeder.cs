using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IPetBreedSeeder : IEntitySeeder
{
    IReadOnlyCollection<PetBreed> Breeds { get; }
}
