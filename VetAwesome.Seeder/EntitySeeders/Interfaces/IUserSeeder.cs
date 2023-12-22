using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IUserSeeder : IEntitySeeder
{
    Task LoadAllUsersAsync(CancellationToken cancellationToken);
    IReadOnlyCollection<User> Users { get; }
}
