using Bogus;
using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.Database;

namespace VetAwesome.Seeder.EntitySeeders;

internal abstract class EntitySeeder<T> where T : class
{
    protected List<T>? entityList = null;
    protected readonly Random rand = new();
    private readonly ILogger logger;
    protected readonly VetAwesomeDb vetDb;
    protected readonly string entityName;
    protected readonly Faker faker = new Faker();

    protected EntitySeeder(ILogger logger
        , VetAwesomeDb vetDb)
    {
        this.logger = logger;
        this.vetDb = vetDb;

        entityName = typeof(T).Name;
    }

    protected IReadOnlyCollection<T> EntityList
    {
        get
        {
            Guard.IsNotNull(entityList);

            return entityList;
        }
    }

    protected E GetRandomElement<E>(IEnumerable<E> elements)
    {
        return elements.ElementAt(rand.Next(0, elements.Count()));
    }

    protected async Task DeleteAllEntitiesAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        var tableName = vetDb.Model.FindEntityType(typeof(T))?.GetSchemaQualifiedTableName() ?? string.Empty;
        await vetDb.Database.ExecuteSqlRawAsync($"delete from [{tableName}]", cancellationToken);
        await vetDb.SaveChangesAsync(cancellationToken);
        logger.LogInformation($"Deleted all in {entityName} entities.");
        entityList = null;
    }

    protected async Task CreateAllEntitiesAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        Guard.IsNotNull(entityList);
        var set = vetDb.Set<T>();
        await set.AddRangeAsync(EntityList, cancellationToken);
        await vetDb.SaveChangesAsync(cancellationToken);
        logger.LogInformation($"Created {entityList.Count:N0} {entityName} entities.");
    }
}
