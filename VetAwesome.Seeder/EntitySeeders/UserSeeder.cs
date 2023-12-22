using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.Database;
using VetAwesome.Seeder.Database.Enums;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class UserSeeder : EntitySeeder<User>, IUserSeeder
{
    public IReadOnlyCollection<User> Users => EntityList;

    private readonly IUserRoleSeeder roleSeeder;
    private readonly ILogger<UserSeeder> logger;

    public UserSeeder(ILogger<UserSeeder> logger
        , VetAwesomeDb vetDb
        , IUserRoleSeeder roleSeeder)
        : base(logger, vetDb)
    {
        this.roleSeeder = roleSeeder;
        this.logger = logger;
    }

    public async Task LoadAllUsersAsync(CancellationToken cancellationToken)
    {
        entityList = await vetDb.Set<User>().ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = [];

        var numVets = 2;
        var vetRole = roleSeeder.Roles.First(r => r.Id == (int)UserRoleType.Veterinarian);
        while (entityList.Count < numVets)
        {
            CreateUser(vetRole);
        }

        var adminRole = roleSeeder.Roles.First(r => r.Id == (int)UserRoleType.Secretary);
        CreateUser(adminRole);

        var ownerRole = roleSeeder.Roles.First(r => r.Id == (int)UserRoleType.Owner);
        CreateUser(ownerRole);

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }

    private void CreateUser(UserRole role)
    {
        var name = faker.Name;
        var user = new User { FirstName = name.FirstName(), LastName = name.LastName(), UserRole = role };
        entityList!.Add(user);
    }
}
