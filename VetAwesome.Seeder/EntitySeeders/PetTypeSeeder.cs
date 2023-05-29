using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Persistence;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal class PetTypeSeeder : EntitySeeder<PetType>, IPetTypeSeeder
{
    private readonly ILogger<PetTypeSeeder> logger;

    public IReadOnlyCollection<PetType> PetTypes => EntityList;

    public PetTypeSeeder(ILogger<PetTypeSeeder> logger
        , VetAwesomeDb vetDb)
        : base(logger, vetDb)
    {
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = new List<PetType>()
        {
            PetType.Create("Cat"),
            PetType.Create("Dog")
        };

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
