using AutoMapper;
using VetAwesome.Bll.Dtos;
using VetAwesome.Bll.Enums;
using VetAwesome.Bll.Interfaces.Services;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.Services
{
    public class SeedService : BaseService, ISeedService
    {
        #region PetBreeds
        private List<PetBreedEntity> dogBreeds = new()
        {
            new PetBreedEntity { Name = "Affenpinscher" },
            new PetBreedEntity { Name = "Afghan Hound" },
            new PetBreedEntity { Name = "Airedale Terrier" },
            new PetBreedEntity { Name = "Akita" },
            new PetBreedEntity { Name = "Alaskan Malamute" },
            new PetBreedEntity { Name = "American English Coonhound" },
            new PetBreedEntity { Name = "American Eskimo" },
            new PetBreedEntity { Name = "American Foxhound" },
            new PetBreedEntity { Name = "American Hairless Terrier" },
            new PetBreedEntity { Name = "American Staffordshire Terrier" },
            new PetBreedEntity { Name = "American Water Spaniel" },
            new PetBreedEntity { Name = "Anatolian Sheepdog" },
            new PetBreedEntity { Name = "Australian Cattle Dog" },
            new PetBreedEntity { Name = "Australian Shepherd" },
            new PetBreedEntity { Name = "Australian Terrier" },
            new PetBreedEntity { Name = "Azawakh" },
            new PetBreedEntity { Name = "Basenji" },
            new PetBreedEntity { Name = "Basset Hound" },
            new PetBreedEntity { Name = "Beagle" },
            new PetBreedEntity { Name = "Bearded Collie" },
            new PetBreedEntity { Name = "Beauceron" },
            new PetBreedEntity { Name = "Bedlington Terrier" },
            new PetBreedEntity { Name = "Belgian Laekenois" },
            new PetBreedEntity { Name = "Belgian Malinois" },
            new PetBreedEntity { Name = "Belgian Sheepdog" },
            new PetBreedEntity { Name = "Belgian Tervuren" },
            new PetBreedEntity { Name = "Bergamasco" },
            new PetBreedEntity { Name = "Berger Picard" },
            new PetBreedEntity { Name = "Bernese Mountain Dog" },
            new PetBreedEntity { Name = "Bichon Frise" },
            new PetBreedEntity { Name = "Black And Tan Coonhound" },
            new PetBreedEntity { Name = "Black Russian Terrier" },
            new PetBreedEntity { Name = "Bluetick Coonhound" },
            new PetBreedEntity { Name = "Bloodhound" },
            new PetBreedEntity { Name = "Boerboel" },
            new PetBreedEntity { Name = "Border Collie" },
            new PetBreedEntity { Name = "Border Terrier" },
            new PetBreedEntity { Name = "Borzoi" },
            new PetBreedEntity { Name = "Boston Terrier" },
            new PetBreedEntity { Name = "Bouvier Des Flandres" },
            new PetBreedEntity { Name = "Boykin Spaniel" },
            new PetBreedEntity { Name = "Boxer" },
            new PetBreedEntity { Name = "Briard" },
            new PetBreedEntity { Name = "Brittany" },
            new PetBreedEntity { Name = "Brussels Griffon" },
            new PetBreedEntity { Name = "Bull Dog" },
            new PetBreedEntity { Name = "Bull Terrier" },
            new PetBreedEntity { Name = "Bullmastiff" },
            new PetBreedEntity { Name = "Cairn Terrier" },
            new PetBreedEntity { Name = "Canaan Dog" },
            new PetBreedEntity { Name = "Cane corso" },
            new PetBreedEntity { Name = "Cardigan Welsh Corgi" },
            new PetBreedEntity { Name = "Cavalier King Charles Spaniel" },
            new PetBreedEntity { Name = "Cesky Terrier" },
            new PetBreedEntity { Name = "Chesapeake Bay Retriever" },
            new PetBreedEntity { Name = "Chihuahua" },
            new PetBreedEntity { Name = "Chinese Crested" },
            new PetBreedEntity { Name = "Chinese Shar Pei" },
            new PetBreedEntity { Name = "Chinook" },
            new PetBreedEntity { Name = "Chow Chow" },
            new PetBreedEntity { Name = "Cirneco dell'Etna" },
            new PetBreedEntity { Name = "Clumber Spaniel" },
            new PetBreedEntity { Name = "Cocker Spaniel-American" },
            new PetBreedEntity { Name = "Cocker Spaniel-English" },
            new PetBreedEntity { Name = "Collie(Rough) & (Smooth)" },
            new PetBreedEntity { Name = "Coton de Tulear" },
            new PetBreedEntity { Name = "Curly Coated Retriever" },
            new PetBreedEntity { Name = "Dachshund" },
            new PetBreedEntity { Name = "Dalmatian" },
            new PetBreedEntity { Name = "Dandie Dinmont Terrier" },
            new PetBreedEntity { Name = "Doberman Pinscher" },
            new PetBreedEntity { Name = "Dogo Argentino" },
            new PetBreedEntity { Name = "English Foxhound" },
            new PetBreedEntity { Name = "English Setter" },
            new PetBreedEntity { Name = "English Springer Spaniel" },
            new PetBreedEntity { Name = "English Toy Spaniel" },
            new PetBreedEntity { Name = "Entlebucher Mountain Dog" },
            new PetBreedEntity { Name = "Field Spaniel" },
            new PetBreedEntity { Name = "Finnish Lapphund" },
            new PetBreedEntity { Name = "Finnish Spitz" },
            new PetBreedEntity { Name = "Flat Coated Retriever" },
            new PetBreedEntity { Name = "Fox Terrier – Smooth" },
            new PetBreedEntity { Name = "Fox Terrier – Wirehair" },
            new PetBreedEntity { Name = "French Bulldog" },
            new PetBreedEntity { Name = "German Pinscher" },
            new PetBreedEntity { Name = "German Shepherd Dog" },
            new PetBreedEntity { Name = "German Shorthaired Pointer" },
            new PetBreedEntity { Name = "German Wirehaired Pointer" },
            new PetBreedEntity { Name = "Giant Schnauzer" },
            new PetBreedEntity { Name = "Glen Imaal Terrier" },
            new PetBreedEntity { Name = "Golden Retriever" },
            new PetBreedEntity { Name = "Gordon Setter" },
            new PetBreedEntity { Name = "Grand Basset" },
            new PetBreedEntity { Name = "Great Dane" },
            new PetBreedEntity { Name = "Great Pyrenees" },
            new PetBreedEntity { Name = "Great Swiss Mountain Dog" },
            new PetBreedEntity { Name = "Greyhound" },
            new PetBreedEntity { Name = "Griffon Vendéen" },
            new PetBreedEntity { Name = "Harrier" },
            new PetBreedEntity { Name = "Havanese" },
            new PetBreedEntity { Name = "Ibizan Hound" },
            new PetBreedEntity { Name = "Irish Setter" },
            new PetBreedEntity { Name = "Irish Terrier" },
            new PetBreedEntity { Name = "Irish Water Spaniel" },
            new PetBreedEntity { Name = "Irish Wolfhound" },
            new PetBreedEntity { Name = "Icelandic Sheepdog" },
            new PetBreedEntity { Name = "Italian Greyhound" },
            new PetBreedEntity { Name = "Japanese Chin" },
            new PetBreedEntity { Name = "Keeshond" },
            new PetBreedEntity { Name = "Kerry Blue Terrier" },
            new PetBreedEntity { Name = "Komondor" },
            new PetBreedEntity { Name = "Kuvasz" },
            new PetBreedEntity { Name = "Labrador Retriever" },
            new PetBreedEntity { Name = "Lagotto Romagnolo" },
            new PetBreedEntity { Name = "Lakeland Terrier" },
            new PetBreedEntity { Name = "Leonberger" },
            new PetBreedEntity { Name = "Lhasa Apso" },
            new PetBreedEntity { Name = "Lowchen(Little Lion Dog)  " },
            new PetBreedEntity { Name = "Maltese" },
            new PetBreedEntity { Name = "Manchester Terrier(Standard & Toy)" },
            new PetBreedEntity { Name = "Mastiff" },
            new PetBreedEntity { Name = "Miniature American Shepherd" },
            new PetBreedEntity { Name = "Miniature Bull Terrier" },
            new PetBreedEntity { Name = "Miniature Pinscher" },
            new PetBreedEntity { Name = "Miniature Schnauzer" },
            new PetBreedEntity { Name = "Neapolitan Mastiff" },
            new PetBreedEntity { Name = "Newfoundland" },
            new PetBreedEntity { Name = "Norfolk Terrier" },
            new PetBreedEntity { Name = "Norrbottenspets" },
            new PetBreedEntity { Name = "Norwegian Elkhound" },
            new PetBreedEntity { Name = "Norwegian Lundehund" },
            new PetBreedEntity { Name = "Norwich Terrier" },
            new PetBreedEntity { Name = "Nova Scotia Duck Tolling Retriever" },
            new PetBreedEntity { Name = "Old English Sheepdog(Bobtail) " },
            new PetBreedEntity { Name = "Otterhound" },
            new PetBreedEntity { Name = "Papillon" },
            new PetBreedEntity { Name = "Parson Russell Terrier" },
            new PetBreedEntity { Name = "Pekingese" },
            new PetBreedEntity { Name = "Pembroke Welsh Corgi" },
            new PetBreedEntity { Name = "Peruvian Inca Orchid" },
            new PetBreedEntity { Name = "Petit Basset Griffon Vendeen" },
            new PetBreedEntity { Name = "Pharaoh Hound" },
            new PetBreedEntity { Name = "Plott Hound" },
            new PetBreedEntity { Name = "Pointer" },
            new PetBreedEntity { Name = "Polish Lowland Sheepdog" },
            new PetBreedEntity { Name = "Pomeranian" },
            new PetBreedEntity { Name = "Poodle(Miniature) " },
            new PetBreedEntity { Name = "Poodle(Standard)  " },
            new PetBreedEntity { Name = "Poodle(Toy)   " },
            new PetBreedEntity { Name = "Portuguese Podengo" },
            new PetBreedEntity { Name = "Portuguese Podengo Pequeno" },
            new PetBreedEntity { Name = "Portuguese Water Dog" },
            new PetBreedEntity { Name = "Pug" },
            new PetBreedEntity { Name = "Puli" },
            new PetBreedEntity { Name = "Pumi" },
            new PetBreedEntity { Name = "Rat Terrier" },
            new PetBreedEntity { Name = "Redbone Coonhound" },
            new PetBreedEntity { Name = "Rhodesian Ridgeback" },
            new PetBreedEntity { Name = "Rottweiler" },
            new PetBreedEntity { Name = "Russell Terrier" },
            new PetBreedEntity { Name = "Saint Bernard" },
            new PetBreedEntity { Name = "Saluki" },
            new PetBreedEntity { Name = "Sloughi" },
            new PetBreedEntity { Name = "Samoyed" },
            new PetBreedEntity { Name = "Schipperke" },
            new PetBreedEntity { Name = "Scottish Deerhound" },
            new PetBreedEntity { Name = "Scottish Terrier" },
            new PetBreedEntity { Name = "Sealyham Terrier" },
            new PetBreedEntity { Name = "Shetland Sheepdog(Sheltie)" },
            new PetBreedEntity { Name = "Shiba Inu" },
            new PetBreedEntity { Name = "Shih Tzu" },
            new PetBreedEntity { Name = "Siberian Husky" },
            new PetBreedEntity { Name = "Silky Terrier" },
            new PetBreedEntity { Name = "Skye Terrier" },
            new PetBreedEntity { Name = "Soft-Coated Wheaten Terrier" },
            new PetBreedEntity { Name = "Spanish Water Dog" },
            new PetBreedEntity { Name = "Spinone Italiano" },
            new PetBreedEntity { Name = "Staffordshire Bull Terrier" },
            new PetBreedEntity { Name = "Standard Schnauzer" },
            new PetBreedEntity { Name = "Sussex Spaniel" },
            new PetBreedEntity { Name = "Tibetan Mastiff" },
            new PetBreedEntity { Name = "Tibetan Spaniel" },
            new PetBreedEntity { Name = "Tibetan Terrier" },
            new PetBreedEntity { Name = "Toy Fox Terrier" },
            new PetBreedEntity { Name = "Treeing Walker Coonhound" },
            new PetBreedEntity { Name = "Vizsla" },
            new PetBreedEntity { Name = "Weimaraner" },
            new PetBreedEntity { Name = "Welsh Springer Spaniel" },
            new PetBreedEntity { Name = "Welsh Terrier" },
            new PetBreedEntity { Name = "West Highland White Terrier" },
            new PetBreedEntity { Name = "Whippet" },
            new PetBreedEntity { Name = "Wirehaired Pointing Griffon" },
            new PetBreedEntity { Name = "Wirehaired Vizsla" },
            new PetBreedEntity { Name = "Xoloitzcuintli" },
            new PetBreedEntity { Name = "Yorkshire Terrier" }
        };
        private List<PetBreedEntity> catBreeds = new()
        {
            new PetBreedEntity { Name = "Abyssinian" },
            new PetBreedEntity { Name = "American Bobtail" },
            new PetBreedEntity { Name = "American Bobtail Shorthair" },
            new PetBreedEntity { Name = "American Curl" },
            new PetBreedEntity { Name = "American Curl Longhair" },
            new PetBreedEntity { Name = "American Shorthair" },
            new PetBreedEntity { Name = "American Wirehair" },
            new PetBreedEntity { Name = "Australian Mist" },
            new PetBreedEntity { Name = "Balinese" },
            new PetBreedEntity { Name = "Bengal" },
            new PetBreedEntity { Name = "Bengal Longhair" },
            new PetBreedEntity { Name = "Birman" },
            new PetBreedEntity { Name = "Bombay" },
            new PetBreedEntity { Name = "British Longhair" },
            new PetBreedEntity { Name = "British Shorthair" },
            new PetBreedEntity { Name = "Burmese" },
            new PetBreedEntity { Name = "Burmilla" },
            new PetBreedEntity { Name = "Burmilla Longhair" },
            new PetBreedEntity { Name = "Chartreux" },
            new PetBreedEntity { Name = "Chausie" },
            new PetBreedEntity { Name = "Cornish Rex" },
            new PetBreedEntity { Name = "Cymric" },
            new PetBreedEntity { Name = "Devon Rex" },
            new PetBreedEntity { Name = "Donskoy" },
            new PetBreedEntity { Name = "Egyptian Mau" },
            new PetBreedEntity { Name = "Exotic Shorthair" },
            new PetBreedEntity { Name = "Havana" },
            new PetBreedEntity { Name = "Himalayan" },
            new PetBreedEntity { Name = "Japanese Bobtail" },
            new PetBreedEntity { Name = "Japanese Bobtail Longhair" },
            new PetBreedEntity { Name = "Khaomanee" },
            new PetBreedEntity { Name = "Korat" },
            new PetBreedEntity { Name = "Kurilian Bobtail" },
            new PetBreedEntity { Name = "Kurilian Bobtail Longhair" },
            new PetBreedEntity { Name = "LaPerm" },
            new PetBreedEntity { Name = "LaPerm Shorthair" },
            new PetBreedEntity { Name = "Lykoi" },
            new PetBreedEntity { Name = "Maine Coon" },
            new PetBreedEntity { Name = "Maine Coon Polydactyl" },
            new PetBreedEntity { Name = "Manx" },
            new PetBreedEntity { Name = "Minuet" },
            new PetBreedEntity { Name = "Minuet Longhair" },
            new PetBreedEntity { Name = "Munchkin" },
            new PetBreedEntity { Name = "Munchkin Longhair" },
            new PetBreedEntity { Name = "Nebelung" },
            new PetBreedEntity { Name = "Norwegian Forest" },
            new PetBreedEntity { Name = "Ocicat" },
            new PetBreedEntity { Name = "Oriental Longhair" },
            new PetBreedEntity { Name = "Oriental Shorthair" },
            new PetBreedEntity { Name = "Persian" },
            new PetBreedEntity { Name = "Peterbald" },
            new PetBreedEntity { Name = "Pixiebob" },
            new PetBreedEntity { Name = "Pixiebob Longhair" },
            new PetBreedEntity { Name = "Ragdoll" },
            new PetBreedEntity { Name = "Russian Blue" },
            new PetBreedEntity { Name = "Savannah" },
            new PetBreedEntity { Name = "Scottish Fold" },
            new PetBreedEntity { Name = "Scottish Fold Longhair" },
            new PetBreedEntity { Name = "Scottish Straight" },
            new PetBreedEntity { Name = "Scottish Straight Longhair" },
            new PetBreedEntity { Name = "Selkirk Rex" },
            new PetBreedEntity { Name = "Selkirk Rex Longhair" },
            new PetBreedEntity { Name = "Siamese" },
            new PetBreedEntity { Name = "Siberian" },
            new PetBreedEntity { Name = "Singapura" },
            new PetBreedEntity { Name = "Snowshoe" },
            new PetBreedEntity { Name = "Somali" },
            new PetBreedEntity { Name = "Sphynx" },
            new PetBreedEntity { Name = "Thai" },
            new PetBreedEntity { Name = "Tonkinese" },
            new PetBreedEntity { Name = "Toyger" },
            new PetBreedEntity { Name = "Turkish Angora" },
            new PetBreedEntity { Name = "Turkish Van" }
        };
        #endregion
        #region States
        private List<StateEntity> states = new()
        {
            new StateEntity { Name = "Alabama", Abbreviation = "NA" },
            new StateEntity { Name = "Alaska", Abbreviation = "NA" },
            new StateEntity { Name = "Arizona", Abbreviation = "NA" },
            new StateEntity { Name = "Arkansas", Abbreviation = "NA" },
            new StateEntity { Name = "California", Abbreviation = "NA" },
            new StateEntity { Name = "Colorado", Abbreviation = "NA" },
            new StateEntity { Name = "Connecticut", Abbreviation = "NA" },
            new StateEntity { Name = "Delaware", Abbreviation = "NA" },
            new StateEntity { Name = "Florida", Abbreviation = "NA" },
            new StateEntity { Name = "Georgia", Abbreviation = "NA" },
            new StateEntity { Name = "Hawaii", Abbreviation = "NA" },
            new StateEntity { Name = "Idaho", Abbreviation = "NA" },
            new StateEntity { Name = "Illinois", Abbreviation = "NA" },
            new StateEntity { Name = "Indiana", Abbreviation = "NA" },
            new StateEntity { Name = "Iowa", Abbreviation = "NA" },
            new StateEntity { Name = "Kansas", Abbreviation = "NA" },
            new StateEntity { Name = "Kentucky", Abbreviation = "NA" },
            new StateEntity { Name = "Louisiana", Abbreviation = "NA" },
            new StateEntity { Name = "Maine", Abbreviation = "NA" },
            new StateEntity { Name = "Maryland", Abbreviation = "NA" },
            new StateEntity { Name = "Massachusetts", Abbreviation = "NA" },
            new StateEntity { Name = "Michigan", Abbreviation = "NA" },
            new StateEntity { Name = "Minnesota", Abbreviation = "NA" },
            new StateEntity { Name = "Mississippi", Abbreviation = "NA" },
            new StateEntity { Name = "Missouri", Abbreviation = "NA" },
            new StateEntity { Name = "Montana", Abbreviation = "NA" },
            new StateEntity { Name = "Nebraska", Abbreviation = "NA" },
            new StateEntity { Name = "Nevada", Abbreviation = "NA" },
            new StateEntity { Name = "New Hampshire", Abbreviation = "NA" },
            new StateEntity { Name = "New Jersey", Abbreviation = "NA" },
            new StateEntity { Name = "New Mexico", Abbreviation = "NA" },
            new StateEntity { Name = "New York", Abbreviation = "NA" },
            new StateEntity { Name = "North Carolina", Abbreviation = "NA" },
            new StateEntity { Name = "North Dakota", Abbreviation = "NA" },
            new StateEntity { Name = "Ohio", Abbreviation = "NA" },
            new StateEntity { Name = "Oklahoma", Abbreviation = "NA" },
            new StateEntity { Name = "Oregon", Abbreviation = "NA" },
            new StateEntity { Name = "Pennsylvania", Abbreviation = "NA" },
            new StateEntity { Name = "Rhode Island", Abbreviation = "NA" },
            new StateEntity { Name = "South Carolina", Abbreviation = "NA" },
            new StateEntity { Name = "South Dakota", Abbreviation = "NA" },
            new StateEntity { Name = "Tennessee", Abbreviation = "NA" },
            new StateEntity { Name = "Texas", Abbreviation = "NA" },
            new StateEntity { Name = "Utah", Abbreviation = "NA" },
            new StateEntity { Name = "Vermont", Abbreviation = "NA" },
            new StateEntity { Name = "Virginia", Abbreviation = "NA" },
            new StateEntity { Name = "Washington", Abbreviation = "NA" },
            new StateEntity { Name = "West Virginia", Abbreviation = "NA" },
            new StateEntity { Name = "Wisconsin", Abbreviation = "NA" },
            new StateEntity { Name = "Wyoming", Abbreviation = "NA" }
        };
        #endregion
        #region Names
        private readonly List<string> maleNames = new()
        {
            "Korbin",
            "Christopher",
            "Jorge",
            "Russell",
            "Camron",
            "Aidan",
            "Darren",
            "Sonny",
            "Jackson",
            "Alexander",
            "Dillon",
            "Christian",
            "Alonso",
            "Fisher",
            "Noel",
            "Lawson",
            "Franco",
            "Harrison",
            "Edgar",
            "Draven",
            "Keith",
            "Jalen",
            "Victor",
            "Kylan",
            "Antonio",
            "Lincoln",
            "Cruz",
            "Abraham",
            "Cordell",
            "Junior",
            "Keaton",
            "Marc",
            "Sam",
            "Trey",
            "Ernesto",
            "Reed",
            "Emilio",
            "Kendall",
            "Dayton",
            "Gerald",
            "Matteo",
            "Hector",
            "Octavio",
            "Winston",
            "Ashton",
            "Everett",
            "Jonah",
            "Colten",
            "Conner",
            "Jair"
        };
        private readonly List<string> femaleNames = new()
        {
            "Annabelle",
            "Evelyn",
            "Alaina",
            "Sariah",
            "Kaitlyn",
            "Madalynn",
            "Kayley",
            "Gina",
            "Campbell",
            "Dakota",
            "Shania",
            "Nathalia",
            "Audrina",
            "Michelle",
            "Chloe",
            "Kristin",
            "Mareli",
            "Adelyn",
            "Shaylee",
            "Karlee",
            "Josephine",
            "Aileen",
            "Beatrice",
            "Lauryn",
            "Diya",
            "Hope",
            "Emelia",
            "Iliana",
            "Jessie",
            "Annalise",
            "Karissa",
            "Karlie",
            "Lucia",
            "Livia",
            "Kiara",
            "Diana",
            "Zariah",
            "Amara",
            "Jazmine",
            "Rosemary",
            "Kenley",
            "Lilah",
            "Karla",
            "Mariela",
            "Abigail",
            "Aimee",
            "Makaila",
            "Ariana",
            "Jordyn",
            "Arabella"
        };
        private readonly List<string> lastNames = new()
            {
                "Martinez",
                "Leon",
                "Key",
                "Miller",
                "Zuniga",
                "Guerrero",
                "Green",
                "Roy",
                "Villarreal",
                "Olsen",
                "Elliott",
                "Moreno",
                "Russo",
                "Flynn",
                "Jackson",
                "Dunlap",
                "Mathews",
                "Montoya",
                "Kramer",
                "Roach",
                "Chandler",
                "Cuevas",
                "Nelson",
                "Zamora",
                "Griffith",
                "Preston",
                "Baker",
                "Mcfarland",
                "Cox",
                "Gross",
                "Gallagher",
                "Dalton",
                "Cameron",
                "Paul",
                "Ponce",
                "Osborne",
                "Quinn",
                "Oconnor",
                "Fitzgerald",
                "Gray",
                "Barrera",
                "Small",
                "Reyes",
                "Greer",
                "Wagner",
                "Hickman",
                "Willis",
                "Glass",
                "Peterson",
                "Cannon"
            };
        private readonly List<string> dogNames = new()
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
            "Brady"
        };
        private readonly List<string> catNames = new()
        {
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
        private readonly List<string> streetNames = new()
        {
            "Lincoln Avenue",
            "Fairway Drive",
            "Magnolia Avenue",
            "Cherry Street",
            "Union Street",
            "14th Street",
            "Railroad Street",
            "Cedar Court",
            "5th Street North",
            "Water Street",
            "Evergreen Drive",
            "Route 5",
            "Monroe Street",
            "Main Street",
            "Belmont Avenue",
            "Delaware Avenue",
            "Route 70",
            "Willow Drive",
            "Winding Way",
            "Main Street East",
            "Charles Street",
            "Linden Avenue",
            "Creekside Drive",
            "Aspen Drive",
            "Route 29"
        };
        private readonly List<string> cityNames = new()
        {
            "San Francisco",
            "Laredo",
            "San Antonio",
            "New York",
            "Columbus",
            "Chula Vista",
            "Sacramento",
            "Riverside",
            "Baton Rouge",
            "Seattle",
            "Tucson",
            "Henderson",
            "Oakland",
            "Norfolk",
            "St. Paul",
            "Albuquerque",
            "Omaha",
            "Garland",
            "Chesapeake",
            "Jersey City",
            "Milwaukee",
            "Chicago",
            "Boston",
            "Plano",
            "San Jose"
        };
        private readonly List<string> phoneNumbers = new()
        {
            "(765) 672-5153",
            "(894) 665-9706",
            "(959) 884-5875",
            "(885) 627-2881",
            "(624) 362-5570",
            "(841) 575-2288",
            "(421) 299-2107",
            "(645) 278-4056",
            "(301) 243-1221",
            "(269) 265-6491",
            "(490) 616-2627",
            "(376) 203-1024",
            "(898) 549-8756",
            "(335) 822-3627",
            "(519) 505-2241",
            "(291) 854-4379",
            "(682) 235-8187",
            "(866) 800-9359",
            "(892) 314-8082",
            "(499) 884-0985",
            "(425) 396-0113",
            "(971) 564-0493",
            "(594) 908-7295",
            "(222) 268-1881",
            "(583) 533-4985"
        };
        #endregion
        private readonly int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly Random rand = new();

        private PetBreedEntity RandomDogBreed
        {
            get { return GetRandomElement(dogBreeds); }
        }

        private PetBreedEntity RandomCatBreed
        {
            get { return GetRandomElement(catBreeds); }
        }

        private StateEntity RandomState
        {
            get { return GetRandomElement(states); }
        }

        private bool RandomBool
        {
            get { return rand.Next(1, 101) > 50; }
        }

        private string RandomLastName
        {
            get { return GetRandomElement(lastNames); }
        }

        private string RandomPhoneNumber
        {
            get { return GetRandomElement(phoneNumbers); }
        }

        private string RandomCityName
        {
            get { return GetRandomElement(cityNames); }
        }

        private string RandomStreetName
        {
            get { return GetRandomElement(streetNames); }
        }

        private string RandomDogName
        {
            get { return GetRandomElement(dogNames); }
        }

        private string RandomCatName
        {
            get { return GetRandomElement(catNames); }
        }

        private string RandomMaleName
        {
            get { return GetRandomElement(maleNames); }
        }

        private string RandomFemaleName
        {
            get { return GetRandomElement(femaleNames); }
        }

        public SeedService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public T GetRandomElement<T>(IEnumerable<T> elements)
        {
            return elements.ElementAt(rand.Next(1, elements.Count()));
        }

        public string GetRandomDigits(int numDigits)
        {
            var digits = string.Empty;
            while (digits.Length < numDigits)
            {
                digits += GetRandomElement(numbers).ToString();
            }

            return digits;
        }

        public void Seed()
        {
            DeleteAll();

            InsertRoles();
            InsertUsers();
            InsertPetTypes();
            InsertStates();
            InsertHouseholds();
        }

        private void DeleteAll()
        {
            uow.Appointments.Delete(uow.Appointments.ReadAll().ToArray());
            uow.PetBreeds.Delete(uow.PetBreeds.ReadAll().ToArray());
            uow.PetTypes.Delete(uow.PetTypes.ReadAll().ToArray());
            uow.Pets.Delete(uow.Pets.ReadAll().ToArray());
            uow.Customers.Delete(uow.Customers.ReadAll().ToArray());
            uow.Households.Delete(uow.Households.ReadAll().ToArray());
            uow.Users.Delete(uow.Users.ReadAll().ToArray());
            uow.Roles.Delete(uow.Roles.ReadAll().ToArray());

            uow.Commit();
        }

        public void CreateAppointments(IEnumerable<Appointment> appointments)
        {
            uow.Appointments.CreateRange(mapper.Map<IEnumerable<AppointmentEntity>>(appointments));
            uow.Commit();
        }

        public PetEntity CreatePet()
        {
            var breeds = dogBreeds;
            var names = dogNames;
            if (RandomBool)
            {
                breeds = catBreeds;
                names = catNames;
            }

            return new PetEntity
            {
                Name = GetRandomElement(names),
                PetBreed = GetRandomElement(breeds)
            };
        }

        private void InsertPetTypes()
        {
            var cat = uow.PetTypes.Create(new PetTypeEntity { Name = "Cat" });
            catBreeds.ForEach(breed => breed.PetType = cat);
            catBreeds = uow.PetBreeds.CreateRange(catBreeds).ToList();

            var dog = uow.PetTypes.Create(new PetTypeEntity { Name = "Dog" });
            dogBreeds.ForEach(breed => breed.PetType = dog);
            dogBreeds = uow.PetBreeds.CreateRange(dogBreeds).ToList();

            uow.Commit();
        }

        private void InsertStates()
        {
            states = uow.States.CreateRange(states).ToList();
            uow.Commit();
        }

        private CustomerEntity CreateCustomer(bool isMale, string? lastName = null)
        {
            var firstName = isMale ? RandomMaleName : RandomFemaleName;
            lastName ??= RandomLastName;
            return new CustomerEntity
            {
                Name = $"{firstName} {lastName}",
                PhoneNumber = RandomPhoneNumber
            };
        }

        private string GetRandomZipCode()
        {
            var zipCode = GetRandomDigits(5);
            if (!RandomBool)
            {
                return zipCode;
            }

            return $"{zipCode}-{GetRandomDigits(4)}";
        }

        private void InsertHouseholds()
        {
            var numHouseholds = rand.Next(10, 101);
            var households = new List<HouseholdEntity>();
            for (var i = 0; i < numHouseholds; i++)
            {
                households.Add(CreateHousehold());
            }

            uow.Households.CreateRange(households);
            uow.Commit();
        }

        public void InsertUsers()
        {
            uow.Users.Create(CreateUser(RoleType.Secretary));
            uow.Users.Create(CreateUser(RoleType.Owner));

            var numVets = rand.Next(3, 7);
            for (var i = 0; i < numVets; i++)
            {
                uow.Users.Create(CreateUser(RoleType.Veterinarian));
            }

            uow.Commit();
        }

        private UserEntity CreateUser(RoleType role)
        {
            var firstName = RandomBool ? RandomMaleName : RandomFemaleName;
            return new UserEntity()
            {
                Name = $"{firstName} {RandomLastName}",
                RoleId = (int)role
            };
        }

        private HouseholdEntity CreateHousehold()
        {
            var household = new HouseholdEntity
            {
                StreetAddress1 = $"{GetRandomDigits(5)} {RandomStreetName}",
                City = RandomCityName,
                State = RandomState,
                ZipCode = GetRandomZipCode(),
                PhoneNumber = RandomPhoneNumber
            };

            var lastName = RandomLastName;
            if (RandomBool)
            {
                household.Customers.Add(CreateCustomer(true, lastName));
            }
            household.Customers.Add(CreateCustomer(false, lastName));

            var petCount = rand.Next(1, 5);
            for (var i = 0; i < petCount; i++)
            {
                household.Pets.Add(CreatePet());
            }

            return household;
        }

        public void InsertRoles()
        {
            foreach (var roleType in Enum.GetValues<RoleType>())
            {
                var role = new RoleEntity() { Name = roleType.ToString(), Id = (int)roleType };
                uow.Roles.Create(role);
            }

            uow.Commit();
        }
    }
}
