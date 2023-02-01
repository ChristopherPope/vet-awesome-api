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

        protected IEnumerable<AppointmentEntity> CreateRandomAppointments(VetDbContext dbContext)
        {
            var vets = EnsureElementsArePresent(CreateRandomUsers, dbContext).Where(u => u.UserRoleId == (int)UserRoleType.Veterinarian);
            var pets = EnsureElementsArePresent(CreateRandomPets, dbContext);
            var startTime = DateTime.Now;
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new AppointmentEntity
                {
                    StartTime = startTime,
                    EndTime = startTime.AddMinutes(30),
                    Pet = GetRandomElement(pets),
                    Veterinarian = GetRandomElement(vets)
                });

                startTime = startTime.AddDays(1);
            }

            dbContext.SaveChanges();
            return dbContext.Set<AppointmentEntity>().ToList();
        }

        protected IEnumerable<PetTypeEntity> CreateRandomPetTypes(VetDbContext dbContext)
        {
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new PetTypeEntity { Name = MakeRandomString() });
            }

            dbContext.SaveChanges();
            return dbContext.Set<PetTypeEntity>().ToList();
        }

        protected IEnumerable<PetBreedEntity> CreateRandomPetBreeds(VetDbContext dbContext)
        {
            var petTypes = EnsureElementsArePresent(CreateRandomPetTypes, dbContext);
            for (var i = 0; i < 10; i++)
            {
                var petType = GetRandomElement(petTypes);
                dbContext.Add(new PetBreedEntity { Name = MakeRandomString(), PetType = petType });
            }

            dbContext.SaveChanges();
            return dbContext.Set<PetBreedEntity>().ToList();
        }

        protected IEnumerable<PetEntity> CreateRandomPets(VetDbContext dbContext)
        {
            var petBreeds = EnsureElementsArePresent(CreateRandomPetBreeds, dbContext);
            var customers = EnsureElementsArePresent(CreateRandomCustomers, dbContext);
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new PetEntity
                {
                    Name = MakeRandomString(),
                    PetBreed = GetRandomElement(petBreeds),
                    Customer = GetRandomElement(customers)
                });
            }

            dbContext.SaveChanges();
            return dbContext.Set<PetEntity>().ToList();
        }

        protected IEnumerable<UserRoleEntity> CreateUserRoles(VetDbContext dbContext)
        {
            foreach (var userRoleType in Enum.GetValues<UserRoleType>())
            {
                var role = new UserRoleEntity()
                {
                    Name = userRoleType.ToString(),
                    Id = (int)userRoleType
                };

                dbContext.Add(role);
            }

            dbContext.SaveChanges();
            return dbContext.Set<UserRoleEntity>().ToList();
        }

        protected IEnumerable<UserEntity> CreateRandomUsers(VetDbContext dbContext)
        {
            EnsureElementsArePresent(CreateUserRoles, dbContext);
            dbContext.Add(new UserEntity { Name = MakeRandomString(), UserRoleId = (int)UserRoleType.Secretary });
            dbContext.Add(new UserEntity { Name = MakeRandomString(), UserRoleId = (int)UserRoleType.Owner });
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new UserEntity { Name = MakeRandomString(), UserRoleId = (int)UserRoleType.Veterinarian });
            }

            dbContext.SaveChanges();
            return dbContext.Set<UserEntity>().ToList();
        }

        protected IEnumerable<CustomerEntity> CreateRandomCustomers(VetDbContext dbContext)
        {
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new CustomerEntity
                {
                    Name = MakeRandomString()
                });
            }

            dbContext.SaveChanges();
            return dbContext.Set<CustomerEntity>().ToList();
        }

        protected IEnumerable<StateEntity> CreateRandomStates(VetDbContext dbContext)
        {
            for (var i = 0; i < 10; i++)
            {
                dbContext.Add(new StateEntity { Name = MakeRandomString(), Abbreviation = MakeRandomString() });
            }

            dbContext.SaveChanges();
            return dbContext.Set<StateEntity>().ToList();
        }

        protected IEnumerable<T> EnsureElementsArePresent<T>(Func<VetDbContext, IEnumerable<T>> createElements, VetDbContext dbContext) where T : class
        {
            var elements = dbContext.Set<T>().ToList();
            if (!elements.Any())
            {
                elements = createElements(dbContext).ToList();
            }

            return elements.ToList();
        }
    }
}
