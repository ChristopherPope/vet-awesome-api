using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IUserRoleSeeder : IEntitySeeder
{
    IReadOnlyCollection<UserRole> Roles { get; }
}
