using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class UserRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<VetDbContext> dbContextOptions;
        private readonly DbConnection dbConnection;

        public UserRepositoryTests()
        {
            dbConnection = new SqliteConnection("Filename=:memory:");
            dbConnection.Open();

            dbContextOptions = new DbContextOptionsBuilder<VetDbContext>()
                .UseSqlite(dbConnection)
                .Options;

            using var dbContext = CreateContext();
            dbContext.Database.EnsureCreated();
        }

        public void Dispose() => dbConnection.Dispose();

        private VetDbContext CreateContext() => new(dbContextOptions);

        [Test]
        public void ReadUsers()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(); // cfg => cfg.RegisterInstance(dbContext).As<VetDbContext>());
            var users = new List<UserEntity>
            {
                new UserEntity { Name = "Road Runner" },
                new UserEntity { Name = "Bugs Bunny" }
            };
            dbContext.AddRange(users);

            var expectedUsers = new List<UserEntity>(users);
            expectedUsers.Reverse();

            var repo = mock.Create<UserRepository>();

            // ACT
            var actualUsers = repo.ReadUsers();

            // ASSERT
            actualUsers.Should().NotBeNull();
            actualUsers.Should().Equal(expectedUsers);
        }
    }
}
