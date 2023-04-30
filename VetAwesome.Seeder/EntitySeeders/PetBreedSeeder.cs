using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class PetBreedSeeder : EntitySeeder<PetBreed>, IPetBreedSeeder
{
    private readonly ILogger<PetBreedSeeder> logger;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPetBreedRepository breedRepo;
    private readonly IPetTypeSeeder petTypeSeeder;

    #region Breed Names
    private List<string> dogBreedNames = new()
    {
        "Affenpinscher",
        "Afghan Hound",
        "Airedale Terrier",
        "Akita",
        "Alaskan Malamute",
        "American English Coonhound",
        "American Eskimo",
        "American Foxhound",
        "American Hairless Terrier",
        "American Staffordshire Terrier",
        "American Water Spaniel",
        "Anatolian Sheepdog",
        "Australian Cattle Dog",
        "Australian Shepherd",
        "Australian Terrier",
        "Azawakh",
        "Basenji",
        "Basset Hound",
        "Beagle",
        "Bearded Collie",
        "Beauceron",
        "Bedlington Terrier",
        "Belgian Laekenois",
        "Belgian Malinois",
        "Belgian Sheepdog",
        "Belgian Tervuren",
        "Bergamasco",
        "Berger Picard",
        "Bernese Mountain Dog",
        "Bichon Frise",
        "Black And Tan Coonhound",
        "Black Russian Terrier",
        "Bluetick Coonhound",
        "Bloodhound",
        "Boerboel",
        "Border Collie",
        "Border Terrier",
        "Borzoi",
        "Boston Terrier",
        "Bouvier Des Flandres",
        "Boykin Spaniel",
        "Boxer",
        "Briard",
        "Brittany",
        "Brussels Griffon",
        "Bull Dog",
        "Bull Terrier",
        "Bullmastiff",
        "Cairn Terrier",
        "Canaan Dog",
        "Cane corso",
        "Cardigan Welsh Corgi",
        "Cavalier King Charles Spaniel",
        "Cesky Terrier",
        "Chesapeake Bay Retriever",
        "Chihuahua",
        "Chinese Crested",
        "Chinese Shar Pei",
        "Chinook",
        "Chow Chow",
        "Cirneco dell'Etna",
        "Clumber Spaniel",
        "Cocker Spaniel-American",
        "Cocker Spaniel-English",
        "Collie(Rough) & (Smooth)",
        "Coton de Tulear",
        "Curly Coated Retriever",
        "Dachshund",
        "Dalmatian",
        "Dandie Dinmont Terrier",
        "Doberman Pinscher",
        "Dogo Argentino",
        "English Foxhound",
        "English Setter",
        "English Springer Spaniel",
        "English Toy Spaniel",
        "Entlebucher Mountain Dog",
        "Field Spaniel",
        "Finnish Lapphund",
        "Finnish Spitz",
        "Flat Coated Retriever",
        "Fox Terrier – Smooth",
        "Fox Terrier – Wirehair",
        "French Bulldog",
        "German Pinscher",
        "German Shepherd Dog",
        "German Shorthaired Pointer",
        "German Wirehaired Pointer",
        "Giant Schnauzer",
        "Glen Imaal Terrier",
        "Golden Retriever",
        "Gordon Setter",
        "Grand Basset",
        "Great Dane",
        "Great Pyrenees",
        "Great Swiss Mountain Dog",
        "Greyhound",
        "Griffon Vendéen",
        "Harrier",
        "Havanese",
        "Ibizan Hound",
        "Irish Setter",
        "Irish Terrier",
        "Irish Water Spaniel",
        "Irish Wolfhound",
        "Icelandic Sheepdog",
        "Italian Greyhound",
        "Japanese Chin",
        "Keeshond",
        "Kerry Blue Terrier",
        "Komondor",
        "Kuvasz",
        "Labrador Retriever",
        "Lagotto Romagnolo",
        "Lakeland Terrier",
        "Leonberger",
        "Lhasa Apso",
        "Lowchen(Little Lion Dog)  ",
        "Maltese",
        "Manchester Terrier(Standard & Toy)",
        "Mastiff",
        "Miniature American Shepherd",
        "Miniature Bull Terrier",
        "Miniature Pinscher",
        "Miniature Schnauzer",
        "Neapolitan Mastiff",
        "Newfoundland",
        "Norfolk Terrier",
        "Norrbottenspets",
        "Norwegian Elkhound",
        "Norwegian Lundehund",
        "Norwich Terrier",
        "Nova Scotia Duck Tolling Retriever",
        "Old English Sheepdog(Bobtail) ",
        "Otterhound",
        "Papillon",
        "Parson Russell Terrier",
        "Pekingese",
        "Pembroke Welsh Corgi",
        "Peruvian Inca Orchid",
        "Petit Basset Griffon Vendeen",
        "Pharaoh Hound",
        "Plott Hound",
        "Pointer",
        "Polish Lowland Sheepdog",
        "Pomeranian",
        "Poodle(Miniature) ",
        "Poodle(Standard)  ",
        "Poodle(Toy)   ",
        "Portuguese Podengo",
        "Portuguese Podengo Pequeno",
        "Portuguese Water Dog",
        "Pug",
        "Puli",
        "Pumi",
        "Rat Terrier",
        "Redbone Coonhound",
        "Rhodesian Ridgeback",
        "Rottweiler",
        "Russell Terrier",
        "Saint Bernard",
        "Saluki",
        "Sloughi",
        "Samoyed",
        "Schipperke",
        "Scottish Deerhound",
        "Scottish Terrier",
        "Sealyham Terrier",
        "Shetland Sheepdog(Sheltie)",
        "Shiba Inu",
        "Shih Tzu",
        "Siberian Husky",
        "Silky Terrier",
        "Skye Terrier",
        "Soft-Coated Wheaten Terrier",
        "Spanish Water Dog",
        "Spinone Italiano",
        "Staffordshire Bull Terrier",
        "Standard Schnauzer",
        "Sussex Spaniel",
        "Tibetan Mastiff",
        "Tibetan Spaniel",
        "Tibetan Terrier",
        "Toy Fox Terrier",
        "Treeing Walker Coonhound",
        "Vizsla",
        "Weimaraner",
        "Welsh Springer Spaniel",
        "Welsh Terrier",
        "West Highland White Terrier",
        "Whippet",
        "Wirehaired Pointing Griffon",
        "Wirehaired Vizsla",
        "Xoloitzcuintli",
        "Yorkshire Terrier"
    };

    private List<string> catBreedNames = new()
    {
        "Abyssinian",
        "American Bobtail",
        "American Bobtail Shorthair",
        "American Curl",
        "American Curl Longhair",
        "American Shorthair",
        "American Wirehair",
        "Australian Mist",
        "Balinese",
        "Bengal",
        "Bengal Longhair",
        "Birman",
        "Bombay",
        "British Longhair",
        "British Shorthair",
        "Burmese",
        "Burmilla",
        "Burmilla Longhair",
        "Chartreux",
        "Chausie",
        "Cornish Rex",
        "Cymric",
        "Devon Rex",
        "Donskoy",
        "Egyptian Mau",
        "Exotic Shorthair",
        "Havana",
        "Himalayan",
        "Japanese Bobtail",
        "Japanese Bobtail Longhair",
        "Khaomanee",
        "Korat",
        "Kurilian Bobtail",
        "Kurilian Bobtail Longhair",
        "LaPerm",
        "LaPerm Shorthair",
        "Lykoi",
        "Maine Coon",
        "Maine Coon Polydactyl",
        "Manx",
        "Minuet",
        "Minuet Longhair",
        "Munchkin",
        "Munchkin Longhair",
        "Nebelung",
        "Norwegian Forest",
        "Ocicat",
        "Oriental Longhair",
        "Oriental Shorthair",
        "Persian",
        "Peterbald",
        "Pixiebob",
        "Pixiebob Longhair",
        "Ragdoll",
        "Russian Blue",
        "Savannah",
        "Scottish Fold",
        "Scottish Fold Longhair",
        "Scottish Straight",
        "Scottish Straight Longhair",
        "Selkirk Rex",
        "Selkirk Rex Longhair",
        "Siamese",
        "Siberian",
        "Singapura",
        "Snowshoe",
        "Somali",
        "Sphynx",
        "Thai",
        "Tonkinese",
        "Toyger",
        "Turkish Angora",
        "Turkish Van"
    };
    #endregion


    public IReadOnlyCollection<PetBreed> Breeds => Entities;

    public PetBreedSeeder(ILogger<PetBreedSeeder> logger, IUnitOfWork unitOfWork, IPetBreedRepository petBreedRepo, IPetTypeSeeder petTypeSeeder)
    {
        this.logger = logger;
        this.unitOfWork = unitOfWork;
        this.breedRepo = petBreedRepo;
        this.petTypeSeeder = petTypeSeeder;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        Guard.IsNull(entities);
        entities = new List<PetBreed>();

        var catType = petTypeSeeder.PetTypes.First(e => e.Name == "Cat");
        Guard.IsNotNull(catType);
        await CreateBreeds(catBreedNames, catType, cancellationToken);

        var dogType = petTypeSeeder.PetTypes.First(e => e.Name == "Dog");
        Guard.IsNotNull(dogType);
        await CreateBreeds(dogBreedNames, dogType, cancellationToken);
    }

    private async Task CreateBreeds(List<string> breedNames, PetType petType, CancellationToken cancellationToken)
    {
        var breeds = new List<PetBreed>();
        foreach (var breedName in breedNames)
        {
            var breed = petType.AddBreed(breedName);
            entities!.Add(breed);

            breeds.Add(breed);
        }

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        await breedRepo.CreateRangeAsync(breeds, cancellationToken);

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation($"Created {breeds.Count:N0} {petType.Name} breeds.");
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await breedRepo.DeleteAllAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Deleted all breeds.");
        entities = null;
    }
}
