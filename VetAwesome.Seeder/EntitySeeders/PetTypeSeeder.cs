﻿using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal class PetTypeSeeder : EntitySeeder<PetType>, IPetTypeSeeder
{
    private readonly ILogger<PetTypeSeeder> logger;

    public IReadOnlyCollection<PetType> PetTypes => Entities;

    public PetTypeSeeder(ILogger<PetTypeSeeder> logger, IUnitOfWork unitOfWork, IPetTypeRepository petTypeRepo)
        : base(unitOfWork, petTypeRepo, logger)
    {
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        entities = new List<PetType>()
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