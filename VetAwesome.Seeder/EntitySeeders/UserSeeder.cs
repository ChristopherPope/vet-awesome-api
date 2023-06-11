using Bogus;
using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Enums;
using VetAwesome.Infrastructure.Persistence;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class UserSeeder : EntitySeeder<User>, IUserSeeder
{
    public IReadOnlyCollection<User> Users => EntityList;

    private readonly IRoleSeeder roleSeeder;
    private readonly ILogger<UserSeeder> logger;

    public UserSeeder(ILogger<UserSeeder> logger
        , VetAwesomeDb vetDb
        , IRoleSeeder roleSeeder)
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
        entityList = new();

        var numVets = 2; // rand.Next(1, 3);
        var vetRole = roleSeeder.Roles.First(r => r.Id == (int)RoleTypes.Veterinarian);
        while (entityList.Count < numVets)
        {
            CreateUser(vetRole);
        }

        var adminRole = roleSeeder.Roles.First(r => r.Id == (int)RoleTypes.Secretary);
        CreateUser(adminRole);

        var ownerRole = roleSeeder.Roles.First(r => r.Id == (int)RoleTypes.Owner);
        CreateUser(ownerRole);

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }

    private void CreateUser(Role role)
    {
        var faker = new Faker();
        var user = User.Create(faker.Name.FullName(), role);
        entityList!.Add(user);
    }
}
