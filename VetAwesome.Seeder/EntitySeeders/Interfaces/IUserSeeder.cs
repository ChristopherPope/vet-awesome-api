using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IUserSeeder : IEntitySeeder
{
    IReadOnlyCollection<User> Users { get; }
}
