using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IUserSeeder : IEntitySeeder
{
    Task LoadAllUsersAsync(CancellationToken cancellationToken);
    IReadOnlyCollection<User> Users { get; }
}
