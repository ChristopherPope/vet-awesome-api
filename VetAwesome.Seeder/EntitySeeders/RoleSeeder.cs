using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Enums;
using VetAwesome.Domain.Repositories;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class RoleSeeder : EntitySeeder<Role>, IRoleSeeder
{
    private readonly ILogger<RoleSeeder> logger;

    public IReadOnlyCollection<Role> Roles => Entities;

    public RoleSeeder(IRoleRepository roleRepo, IUnitOfWork unitOfWork, ILogger<RoleSeeder> logger)
        : base(unitOfWork, roleRepo, logger)
    {
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        entities = new();

        var roleTypes = Enum.GetValues<RoleTypes>();
        foreach (var roleType in roleTypes)
        {
            var role = Role.Create((int)roleType, roleType.ToString());
            entities.Add(role);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
