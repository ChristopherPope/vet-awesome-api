using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal class PetTypeSeeder : EntitySeeder<PetType>, IPetTypeSeeder
{
    private readonly ILogger<PetTypeSeeder> logger;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPetTypeRepository petTypeRepo;

    public IReadOnlyCollection<PetType> PetTypes => Entities;

    public PetTypeSeeder(ILogger<PetTypeSeeder> logger, IUnitOfWork unitOfWork, IPetTypeRepository petTypeRepo)
    {
        this.logger = logger;
        this.unitOfWork = unitOfWork;
        this.petTypeRepo = petTypeRepo;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        try
        {
            entities = new List<PetType>()
            {
                await petTypeRepo.CreateAsync(PetType.Create("Cat"), cancellationToken),
                await petTypeRepo.CreateAsync(PetType.Create("Dog"), cancellationToken)
            };

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            await unitOfWork.SaveChangesAsync(cancellationToken);

            logger.LogInformation($"Created {Entities.Count:N0} Pet Types.");
        }
        catch (Exception ex)
        {
            logger.LogError("Failed to create entities.", ex);
        }
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await petTypeRepo.DeleteAllAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Deleted all pet types.");
        entities = null;
    }
}
