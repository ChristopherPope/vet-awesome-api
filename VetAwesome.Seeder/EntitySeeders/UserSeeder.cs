using Bogus;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Enums;
using VetAwesome.Domain.Repositories;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class UserSeeder : EntitySeeder<User>, IUserSeeder
{
    public IReadOnlyCollection<User> Users => Entities;

    private readonly IRoleSeeder roleSeeder;
    private readonly ILogger<UserSeeder> logger;

    public UserSeeder(IRoleSeeder roleSeeder, IUserRepository userRepo, IUnitOfWork unitOfWork, ILogger<UserSeeder> logger)
        : base(unitOfWork, userRepo, logger)
    {
        this.roleSeeder = roleSeeder;
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        entities = new();

        var numVets = rand.Next(2, 6);
        var vetRole = roleSeeder.Roles.First(r => r.Id == (int)RoleTypes.Veterinarian);
        while (entities.Count < numVets)
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
        entities!.Add(user);
    }
}
