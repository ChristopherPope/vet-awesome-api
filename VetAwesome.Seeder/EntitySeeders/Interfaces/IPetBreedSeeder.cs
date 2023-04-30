using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IPetBreedSeeder : IEntitySeeder
{
    IReadOnlyCollection<PetBreed> Breeds { get; }
}
