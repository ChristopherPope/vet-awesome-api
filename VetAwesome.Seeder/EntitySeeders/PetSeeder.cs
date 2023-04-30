using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class PetSeeder : EntitySeeder<Pet>, IPetSeeder
{
    #region Names
    private readonly List<string> petNames = new()
        {
            "Millie",
            "Maggie",
            "Winston",
            "Athena",
            "Max",
            "Sugar",
            "Samantha",
            "Kobe",
            "Zeus",
            "Lucky",
            "Frankie",
            "Nikki",
            "Cocoa",
            "Callie",
            "Bud",
            "Whiskey",
            "Layla",
            "Katie",
            "Oakley",
            "Dodger",
            "Sparky",
            "Minnie",
            "Nala",
            "Jax",
            "Brady",
            "Dusty",
            "Felix",
            "Misty",
            "Zoe",
            "Murphy",
            "Sweetie",
            "Twiggy",
            "Pumpkin",
            "Salem",
            "BatMan",
            "Loki",
            "Emma",
            "Belle",
            "Beyonce",
            "Izzy",
            "Tucker",
            "Fiona",
            "Daisy",
            "Cher",
            "Chloe",
            "Milo",
            "Harley",
            "Sebastian",
            "Houdini",
            "Sox"
        };
    #endregion

    private readonly IUnitOfWork unitOfWork;
    private readonly IPetRepository petRepo;
    private readonly ILogger<PetSeeder> logger;
    private readonly IPetBreedSeeder breedSeeder;
    private readonly ICustomerSeeder customerSeeder;
    private readonly Random rand = new Random();

    public IReadOnlyCollection<Pet> Pets => Entities;

    public PetSeeder(IUnitOfWork unitOfWork, IPetRepository petRepo, ILogger<PetSeeder> logger, IPetBreedSeeder breedSeeder, ICustomerSeeder customerSeeder)
    {
        this.unitOfWork = unitOfWork;
        this.petRepo = petRepo;
        this.logger = logger;
        this.breedSeeder = breedSeeder;
        this.customerSeeder = customerSeeder;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        entities = new List<Pet>();

        var breeds = breedSeeder.Breeds;
        foreach (var customer in customerSeeder.Customers)
        {
            var petCount = rand.Next(1, 5);
            while (customer.Pets.Count < petCount)
            {
                var petName = petNames[rand.Next(0, petNames.Count)];
                var breed = breeds.ElementAt(rand.Next(0, breeds.Count));

                var pet = customer.AddPet(petName, breed);
                entities.Add(pet);
            }
        }

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        await petRepo.CreateRangeAsync(entities, cancellationToken);

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation($"Created {entities.Count:N0} pets.");
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await petRepo.DeleteAllAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Deleted all pets.");
        entities = null;
    }
}
