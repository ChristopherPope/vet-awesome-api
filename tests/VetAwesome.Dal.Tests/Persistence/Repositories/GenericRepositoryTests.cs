using VetAwesome.Dal.Persistence;

namespace VetAwesome.Dal.Tests.Persistence.Repositories
{
    public class GenericRepositoryTests : RepositoryTests
    {
        [Test]
        public void ReadById()
        {
            // ARRANGE
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            CreateRoles(dbContext);
            var users = MakeUsers();
            dbContext.AddRange(users);
            dbContext.SaveChanges();

            var expectedUser = users.First();
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
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            CreateRoles(dbContext);
            var expectedUsers = MakeUsers();
            dbContext.AddRange(expectedUsers);
            dbContext.SaveChanges();

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
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());

            CreateRoles(dbContext);
            var expectedUsers = MakeUsers();
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
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            CreateRoles(dbContext);
            var expectedUser = MakeUsers().First();
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
            CreateRoles(dbContext);
            var expectedUsers = MakeUsers().ToList();
            dbContext.AddRange(expectedUsers);
            dbContext.SaveChanges();

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
            CreateRoles(dbContext);
            var user = MakeUsers().First();
            dbContext.AddRange(user);
            dbContext.SaveChanges();

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
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            CreateRoles(dbContext);
            dbContext.AddRange(MakeUsers());
            dbContext.SaveChanges();

            var repo = mock.Create<GenericRepository<UserEntity>>();

            // ACT
            var isEmpty = repo.IsEmpty();

            // ASSERT
            isEmpty.Should().BeFalse();
        }

        private IEnumerable<UserEntity> MakeUsers()
        {
            return new List<UserEntity>
            {
                new UserEntity { Name = "Road Runner", RoleId = 1, Id = 1 },
                new UserEntity { Name = "Bugs Bunny", RoleId = 1, Id = 2 }
            };
        }

        private void CreateRoles(VetDbContext dbContext)
        {
            dbContext.AddRange(new List<RoleEntity> { new RoleEntity { Name = "President", Id = 1 } });
            dbContext.SaveChanges();
        }
    }
}
