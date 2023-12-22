using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.Database;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class PetSeeder : EntitySeeder<Pet>, IPetSeeder
{
    #region Names
    private readonly List<string> petNames =
        [
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
        ];
    #endregion

    private readonly ILogger<PetSeeder> logger;
    private readonly IPetBreedSeeder breedSeeder;
    private readonly ICustomerSeeder customerSeeder;

    public IReadOnlyCollection<Pet> Pets => EntityList;

    public PetSeeder(ILogger<PetSeeder> logger
        , VetAwesomeDb vetDb
        , IPetBreedSeeder breedSeeder
        , ICustomerSeeder customerSeeder)
        : base(logger, vetDb)
    {
        this.logger = logger;
        this.breedSeeder = breedSeeder;
        this.customerSeeder = customerSeeder;
    }

    public async Task LoadAllPetsAsync(CancellationToken cancellationToken)
    {
        entityList = await vetDb
            .Set<Pet>()
            .Include(p => p.Customer)
            .ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entityList);
        entityList = [];

        foreach (var customer in customerSeeder.Customers)
        {
            var petCount = rand.Next(1, 5);
            for (var i = 0; i < petCount; i++)
            {
                var pet = new Pet
                {
                    Name = GetRandomElement(petNames),
                    PetBreed = GetRandomElement(breedSeeder.Breeds),
                    Customer = customer,
                };

                entityList.Add(pet);
            }
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }
}
