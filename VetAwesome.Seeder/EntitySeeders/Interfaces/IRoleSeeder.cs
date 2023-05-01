using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IRoleSeeder : IEntitySeeder
{
    IReadOnlyCollection<Role> Roles { get; }
}
