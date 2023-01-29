using AutoMapper;
using Microsoft.AspNetCore.Http;
using VetAwesome.Bll.Enums;
using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Bll.Interfaces.Services;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.Services
{
    public class SeedService : BaseService, ISeedService
    {
        #region PetBreed Entities
        private List<PetBreedEntity> dogBreedEntities = new()
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
        private List<PetBreedEntity> catBreedEntities = new()
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
        #region State Entities
        private List<StateEntity> stateEntities = new()
        {
            new StateEntity { Name = "Alabama", Abbreviation = "AL" },
            new StateEntity { Name = "Alaska", Abbreviation = "AK" },
            new StateEntity { Name = "Arizona", Abbreviation = "AR" },
            new StateEntity { Name = "Arkansas", Abbreviation = "AR" },
            new StateEntity { Name = "California", Abbreviation = "CA" },
            new StateEntity { Name = "Colorado", Abbreviation = "CO" },
            new StateEntity { Name = "Connecticut", Abbreviation = "CT" },
            new StateEntity { Name = "Delaware", Abbreviation = "DE" },
            new StateEntity { Name = "Florida", Abbreviation = "FL" },
            new StateEntity { Name = "Georgia", Abbreviation = "GA" },
            new StateEntity { Name = "Hawaii", Abbreviation = "HI" },
            new StateEntity { Name = "Idaho", Abbreviation = "ID" },
            new StateEntity { Name = "Illinois", Abbreviation = "IL" },
            new StateEntity { Name = "Indiana", Abbreviation = "IN" },
            new StateEntity { Name = "Iowa", Abbreviation = "IA" },
            new StateEntity { Name = "Kansas", Abbreviation = "KS" },
            new StateEntity { Name = "Kentucky", Abbreviation = "KY" },
            new StateEntity { Name = "Louisiana", Abbreviation = "LA" },
            new StateEntity { Name = "Maine", Abbreviation = "ME" },
            new StateEntity { Name = "Maryland", Abbreviation = "MD" },
            new StateEntity { Name = "Massachusetts", Abbreviation = "MA" },
            new StateEntity { Name = "Michigan", Abbreviation = "MI" },
            new StateEntity { Name = "Minnesota", Abbreviation = "MN" },
            new StateEntity { Name = "Mississippi", Abbreviation = "MS" },
            new StateEntity { Name = "Missouri", Abbreviation = "MO" },
            new StateEntity { Name = "Montana", Abbreviation = "MT" },
            new StateEntity { Name = "Nebraska", Abbreviation = "NE" },
            new StateEntity { Name = "Nevada", Abbreviation = "NV" },
            new StateEntity { Name = "New Hampshire", Abbreviation = "NH" },
            new StateEntity { Name = "New Jersey", Abbreviation = "NJ" },
            new StateEntity { Name = "New Mexico", Abbreviation = "NM" },
            new StateEntity { Name = "New York", Abbreviation = "NY" },
            new StateEntity { Name = "North Carolina", Abbreviation = "NC" },
            new StateEntity { Name = "North Dakota", Abbreviation = "ND" },
            new StateEntity { Name = "Ohio", Abbreviation = "OH" },
            new StateEntity { Name = "Oklahoma", Abbreviation = "OK" },
            new StateEntity { Name = "Oregon", Abbreviation = "OR" },
            new StateEntity { Name = "Pennsylvania", Abbreviation = "PA" },
            new StateEntity { Name = "Rhode Island", Abbreviation = "RI" },
            new StateEntity { Name = "South Carolina", Abbreviation = "SC" },
            new StateEntity { Name = "South Dakota", Abbreviation = "SD" },
            new StateEntity { Name = "Tennessee", Abbreviation = "TN" },
            new StateEntity { Name = "Texas", Abbreviation = "TX" },
            new StateEntity { Name = "Utah", Abbreviation = "UT" },
            new StateEntity { Name = "Vermont", Abbreviation = "VT" },
            new StateEntity { Name = "Virginia", Abbreviation = "VA" },
            new StateEntity { Name = "Washington", Abbreviation = "WA" },
            new StateEntity { Name = "West Virginia", Abbreviation = "WV" },
            new StateEntity { Name = "Wisconsin", Abbreviation = "WI" },
            new StateEntity { Name = "Wyoming", Abbreviation = "WY" }
        };
        #endregion
        private readonly IRandomHouseholdMaker householdMaker;
        private readonly IRandomUserMaker userMaker;
        private readonly IRandomAppointmentMaker appointmentMaker;
        private readonly Random rand = new();

        public SeedService(IUnitOfWork uow,
            IMapper mapper,
            IHttpContextAccessor httpAccessor,
            IRandomHouseholdMaker householdMaker,
            IRandomUserMaker userMaker,
            IRandomAppointmentMaker appointmentMaker)
            : base(uow, mapper, httpAccessor)
        {
            this.userMaker = userMaker;
            this.householdMaker = householdMaker;
            this.appointmentMaker = appointmentMaker;
        }

        public void SeedAppointments()
        {
            DeleteAppointments();
            InsertAppointments();
        }

        public void SeedAllData()
        {
            DeleteAll();

            InsertRoles();
            InsertPetTypes();
            InsertStates();

            InsertUsers();
            InsertHouseholds();
            InsertAppointments();
        }

        private void DeleteAll()
        {
            DeleteAppointments();
            uow.PetBreeds.Delete(uow.PetBreeds.ReadAll().ToArray());
            uow.PetTypes.Delete(uow.PetTypes.ReadAll().ToArray());
            uow.Pets.Delete(uow.Pets.ReadAll().ToArray());
            uow.Customers.Delete(uow.Customers.ReadAll().ToArray());
            uow.Households.Delete(uow.Households.ReadAll().ToArray());
            uow.Users.Delete(uow.Users.ReadAll().ToArray());
            uow.Roles.Delete(uow.Roles.ReadAll().ToArray());
            uow.States.Delete(uow.States.ReadAll().ToArray());

            uow.Commit();
        }

        private void DeleteAppointments()
        {
            uow.Appointments.Delete(uow.Appointments.ReadAll().ToArray());
            uow.Commit();
        }

        private void InsertAppointments()
        {
            var appointments = new List<AppointmentEntity>();
            var startTime = new TimeOnly(8, 0, 0);
            for (var i = 0; i < 32; i++)
            {
                appointments.AddRange(appointmentMaker.MakeAppointments(startTime.AddMinutes(i * 15)));
            }

            uow.Appointments.CreateRange(appointments);
            uow.Commit();
        }

        private void InsertPetTypes()
        {
            var cat = uow.PetTypes.Create(new PetTypeEntity { Name = "Cat" });
            foreach (var catBreed in catBreedEntities)
            {
                catBreed.PetType = cat;
            }
            catBreedEntities = uow.PetBreeds.CreateRange(catBreedEntities).ToList();

            var dog = uow.PetTypes.Create(new PetTypeEntity { Name = "Dog" });
            foreach (var dogBreed in dogBreedEntities)
            {
                dogBreed.PetType = dog;
            }
            dogBreedEntities = uow.PetBreeds.CreateRange(dogBreedEntities).ToList();
        }

        private void InsertStates()
        {
            stateEntities = uow.States.CreateRange(stateEntities).ToList();
            uow.Commit();
        }

        private void InsertHouseholds()
        {
            var numHouseholds = rand.Next(30, 101);
            var households = new List<HouseholdEntity>();
            for (var i = 0; i < numHouseholds; i++)
            {
                households.Add(householdMaker.MakeHousehold());
            }

            uow.Households.CreateRange(households);
            uow.Commit();
        }

        public void InsertUsers()
        {
            uow.Users.Create(userMaker.MakeUser(RoleType.Secretary));
            uow.Users.Create(userMaker.MakeUser(RoleType.Owner));

            for (var i = 0; i < 3; i++)
            {
                uow.Users.Create(userMaker.MakeUser(RoleType.Veterinarian));
            }

            uow.Commit();
        }

        public void InsertRoles()
        {
            foreach (var roleType in Enum.GetValues<RoleType>())
            {
                var role = new RoleEntity()
                {
                    Name = roleType.ToString(),
                    Id = (int)roleType
                };

                uow.Roles.Create(role);
            }

            uow.Commit();
        }
    }
}
