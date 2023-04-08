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
            var users = CreateRandomUsers(dbContext);
            var expectedUsers = users.OrderBy(users => users.Name).ToList();

            var repo = mock.Create<UserRepository>();

            // ACT
            var actualUsers = repo.ReadUsers().ToList();

            // ASSERT
            actualUsers.Should().NotBeNull();
            actualUsers.Should().BeEquivalentTo(expectedUsers);
        }
    }
}
