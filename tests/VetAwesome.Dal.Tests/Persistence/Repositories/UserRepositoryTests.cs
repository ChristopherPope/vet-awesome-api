namespace VetAwesome.Dal.Tests.Persistence.Repositories
{
    public class UserRepositoryTests : RepositoryTests
    {
        [Test]
        public void ReadUsers()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            var roles = new List<RoleEntity> { new RoleEntity { Name = "President", Id = 1 } };
            dbContext.AddRange(roles);

            var users = new List<UserEntity>
            {
                new UserEntity { Name = "Road Runner", RoleId = 1 },
                new UserEntity { Name = "Bugs Bunny", RoleId = 1 }
            };
            dbContext.AddRange(users);
            dbContext.SaveChanges();

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
