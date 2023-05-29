using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Enums;
using VetAwesome.Infrastructure.Persistence;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class RoleSeeder : EntitySeeder<Role>, IRoleSeeder
{
    private readonly ILogger<RoleSeeder> logger;

    public IReadOnlyCollection<Role> Roles => EntityList;

    public RoleSeeder(ILogger<RoleSeeder> logger
        , VetAwesomeDb vetDb)
        : base(logger, vetDb)
    {
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = new();

        var roleTypes = Enum.GetValues<RoleTypes>();
        foreach (var roleType in roleTypes)
        {
            var role = Role.Create((int)roleType, roleType.ToString());
            entityList.Add(role);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
