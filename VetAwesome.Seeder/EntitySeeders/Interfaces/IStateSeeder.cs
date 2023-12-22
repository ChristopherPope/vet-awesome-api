using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IStateSeeder : IEntitySeeder
{
    IReadOnlyCollection<State> States { get; }
}
