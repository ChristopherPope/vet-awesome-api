using Microsoft.Data.Sqlite;
using System.Data.Common;
using VetAwesome.Bll.Enums;
using VetAwesome.Dal.Persistence;

namespace VetAwesome.Dal.Tests.Persistence.Repositories
{
    public abstract class RepositoryTests
    {
        protected DbContextOptions<VetDbContext> dbContextOptions;
        protected DbConnection dbConnection;
        protected readonly Random rand = new();
        protected readonly string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        [SetUp]
        public void SetUp()
        {
            dbConnection = new SqliteConnection("Filename=:memory:");
            dbConnection.Open();

            dbContextOptions = new DbContextOptionsBuilder<VetDbContext>()
                .UseSqlite(dbConnection)
                .Options;

            using var dbContext = CreateContext();
            dbContext.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            using var dbContext = CreateContext();
            dbContext.Database.EnsureDeleted();
            dbConnection.Close();
        }

        private void Dispose() => dbConnection.Dispose();

        protected VetDbContext CreateContext() => new(dbContextOptions);

        protected string MakeRandomString()
        {
            var length = rand.Next(5, 26);
            var text = string.Empty;
            while (text.Length < length)
            {
                text += letters[rand.Next(0, letters.Length)];
            }

            return text;
        }

        protected T GetRandomElement<T>(IEnumerable<T> elements)
        {
            return elements.ElementAt(rand.Next(0, elements.Count()));
        }

        protected IEnumerable<T> GetRandomElements<T>(IEnumerable<T> elements)
        {
            var resultElements = new List<T>();
            while (resultElements.Count < rand.Next(1, 6))
            {
                resultElements.Add(GetRandomElement<T>(elements));
            }

            return resultElements;
        }

        protected IEnumerable<PetTypeEntity> CreateRandomPetTypes()
        {
            using var dbContext = CreateContext();
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new PetTypeEntity { Name = MakeRandomString() });
            }

            dbContext.SaveChanges();
            return dbContext.Set<PetTypeEntity>().ToList();
        }

        protected IEnumerable<PetBreedEntity> CreateRandomPetBreeds()
        {
            using var dbContext = CreateContext();
            var petTypes = EnsureElementsArePresent(CreateRandomPetTypes);
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new PetBreedEntity { Name = MakeRandomString(), PetType = GetRandomElement(petTypes) });
            }

            dbContext.SaveChanges();
            return dbContext.Set<PetBreedEntity>().ToList();
        }

        protected IEnumerable<PetEntity> CreateRandomPets()
        {
            using var dbContext = CreateContext();
            var petBreeds = EnsureElementsArePresent(CreateRandomPetBreeds);
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new PetEntity { Name = MakeRandomString(), PetBreed = GetRandomElement(petBreeds) });
            }

            dbContext.SaveChanges();
            return dbContext.Set<PetEntity>().ToList();
        }

        protected IEnumerable<RoleEntity> CreateRoles()
        {
            using var dbContext = CreateContext();
            foreach (var roleType in Enum.GetValues<RoleType>())
            {
                var role = new RoleEntity()
                {
                    Name = roleType.ToString(),
                    Id = (int)roleType
                };

                dbContext.Add(role);
            }

            dbContext.SaveChanges();
            return dbContext.Set<RoleEntity>().ToList();
        }

        protected IEnumerable<UserEntity> CreateRandomUsers()
        {
            using var dbContext = CreateContext();
            EnsureElementsArePresent(CreateRoles);
            dbContext.Add(new UserEntity { Name = MakeRandomString(), RoleId = (int)RoleType.Secretary });
            dbContext.Add(new UserEntity { Name = MakeRandomString(), RoleId = (int)RoleType.Owner });
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new UserEntity { Name = MakeRandomString(), RoleId = (int)RoleType.Veterinarian });
            }

            dbContext.SaveChanges();
            return dbContext.Set<UserEntity>().ToList();
        }

        protected IEnumerable<CustomerEntity> CreateRandomCustomers()
        {
            using var dbContext = CreateContext();
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new CustomerEntity { Name = MakeRandomString(), PhoneNumber = MakeRandomString() });
            }

            dbContext.SaveChanges();
            return dbContext.Set<CustomerEntity>().ToList();
        }

        protected IEnumerable<StateEntity> CreateRandomStates()
        {
            using var dbContext = CreateContext();
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new StateEntity { Name = MakeRandomString(), Abbreviation = MakeRandomString() });
            }

            dbContext.SaveChanges();
            return dbContext.Set<StateEntity>().ToList();
        }

        protected IEnumerable<HouseholdEntity> CreateRandomHouseholds()
        {
            using var dbContext = CreateContext();
            var pets = EnsureElementsArePresent(CreateRandomPets);
            var customers = EnsureElementsArePresent(CreateRandomCustomers);
            var states = EnsureElementsArePresent(CreateRandomStates);
            for (var i = 0; i < 10; i++)
            {
                var household = new HouseholdEntity
                {
                    StreetAddress1 = MakeRandomString(),
                    City = MakeRandomString(),
                    ZipCode = MakeRandomString(),
                    State = GetRandomElement(states)
                };
                household.Pets.Add(GetRandomElement(pets));
                household.Pets.Add(GetRandomElement(pets));
                household.Pets.Add(GetRandomElement(pets));

                household.Customers.Add(GetRandomElement(customers));
                household.Customers.Add(GetRandomElement(customers));

                dbContext.Add(household);
            }

            dbContext.SaveChanges();
            return dbContext.Set<HouseholdEntity>().ToList();
        }

        protected IEnumerable<T> EnsureElementsArePresent<T>(Func<IEnumerable<T>> createElements) where T : class
        {
            using var dbContext = CreateContext();
            var elements = dbContext.Set<T>().ToList();
            if (!elements.Any())
            {
                elements = createElements().ToList();
            }

            return elements.ToList();
        }
    }
}
