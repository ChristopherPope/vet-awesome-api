using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IStateSeeder : IEntitySeeder
{
    IReadOnlyCollection<State> States { get; }
}
