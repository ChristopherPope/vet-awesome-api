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

    private readonly ILogger<PetSeeder> logger;
    private readonly IPetBreedSeeder breedSeeder;
    private readonly ICustomerSeeder customerSeeder;

    public IReadOnlyCollection<Pet> Pets => Entities;

    public PetSeeder(IUnitOfWork unitOfWork, IPetRepository petRepo, ILogger<PetSeeder> logger, IPetBreedSeeder breedSeeder, ICustomerSeeder customerSeeder)
        : base(unitOfWork, petRepo, logger)
    {
        this.logger = logger;
        this.breedSeeder = breedSeeder;
        this.customerSeeder = customerSeeder;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        entities = new List<Pet>();

        foreach (var customer in customerSeeder.Customers)
        {
            var petCount = rand.Next(1, 5);
            while (customer.Pets.Count < petCount)
            {
                var petName = GetRandomElement(petNames);
                var breed = GetRandomElement(breedSeeder.Breeds);

                var pet = customer.AddPet(petName, breed);
                entities.Add(pet);
            }
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
