namespace VetAwesome.Dal.Tests.Persistence.Repositories
{
    public class GenericRepositoryTests : RepositoryTests
    {
        [Test]
        public void ReadById()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            var expectedUser = CreateRandomUsers(dbContext).First();
            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            var actualUser = repo.ReadById(expectedUser.Id);

            // ASSERT
            actualUser.Should().NotBeNull();
            actualUser.Should().BeEquivalentTo(expectedUser);
        }

        [Test]
        public void ReadAll()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            var expectedUsers = CreateRandomUsers(dbContext);

            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            var actualUsers = repo.ReadAll();

            // ASSERT
            actualUsers.Should().NotBeNull();
            actualUsers.Should().BeEquivalentTo(expectedUsers);
        }

        [Test]
        public void CreateRange()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(CreateContext()).As<DbContext>());
            var expectedUsers = CreateRandomUsers(dbContext);
            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            var actualUsers = repo.CreateRange(expectedUsers);

            // ASSERT
            actualUsers.Should().NotBeNull();
            actualUsers.Should().BeEquivalentTo(expectedUsers);
        }

        [Test]
        public void Create()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            var expectedUser = CreateRandomUsers(dbContext).First();
            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            var actualUser = repo.Create(expectedUser);

            // ASSERT
            actualUser.Should().NotBeNull();
            actualUser.Should().BeEquivalentTo(expectedUser);
        }

        [Test]
        public void Delete()
        {
            // ARRANGE
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            var expectedUsers = CreateRandomUsers(dbContext).ToList();

            var userToRemove = expectedUsers.First();
            expectedUsers.Remove(userToRemove);
            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            repo.Delete(userToRemove);
            dbContext.SaveChanges();
            var actualUsers = repo.ReadAll().ToList();

            // ASSERT
            actualUsers.Should().NotBeNull();
            actualUsers.Should().BeEquivalentTo(expectedUsers);
        }

        [Test]
        public void Update()
        {
            // ARRANGE
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            var user = CreateRandomUsers(dbContext).First();

            var expectedUser = new UserEntity { Name = "New Name", RoleId = user.RoleId, Role = user.Role, Id = user.Id };
            dbContext.Entry(user).State = EntityState.Detached;
            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            repo.Update(expectedUser);
            dbContext.SaveChanges();
            var actualUser = repo.ReadById(expectedUser.Id);

            // ASSERT
            actualUser.Should().NotBeNull();
            actualUser.Should().BeEquivalentTo(expectedUser);
        }

        [Test]
        public void IsEmtpy()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            CreateRandomUsers(dbContext);
            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            var isEmpty = repo.IsEmpty();

            // ASSERT
            isEmpty.Should().BeFalse();
        }
    }
}
