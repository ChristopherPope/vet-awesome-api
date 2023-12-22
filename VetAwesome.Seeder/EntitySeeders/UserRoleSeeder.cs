using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.Database;
using VetAwesome.Seeder.Database.Enums;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class UserRoleSeeder : EntitySeeder<UserRole>, IUserRoleSeeder
{
    private readonly ILogger<UserRoleSeeder> logger;

    public IReadOnlyCollection<UserRole> Roles => EntityList;

    public UserRoleSeeder(ILogger<UserRoleSeeder> logger
        , VetAwesomeDb vetDb)
        : base(logger, vetDb)
    {
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = [];

        var roleTypes = Enum.GetValues<UserRoleType>();
        foreach (var roleType in roleTypes)
        {
            var role = new UserRole { Id = (int)roleType, Name = roleType.ToString() };
            entityList.Add(role);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
