namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IEntitySeeder
{
    Task CreateAsync(CancellationToken cancellationToken);
    Task DeleteAllAsync(CancellationToken cancellationToken);
}
