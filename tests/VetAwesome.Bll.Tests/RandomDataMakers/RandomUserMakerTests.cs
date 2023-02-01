using VetAwesome.Bll.Enums;
using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Bll.RandomDataMakers;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomUserMakerTests
    {
        [Test]
        public void MakeUser()
        {
            // ARRANGE
            var mock = AutoMock.GetLoose();
            var mockNameMaker = mock.Mock<IRandomNameMaker>();
            mockNameMaker.Setup(m => m.MakeFirstName()).Returns("Bugs");
            mockNameMaker.Setup(m => m.MakeLastName()).Returns("Bunny");
            var expectedRole = UserRoleType.Owner;

            var maker = mock.Create<RandomUserMaker>();

            // ACT
            var actualUser = maker.MakeUser(expectedRole);

            // ASSERT
            actualUser.Should().NotBeNull();
            actualUser.Name.Should().NotBeNullOrEmpty();
            actualUser.UserRoleId.Should().Be((int)expectedRole);
        }
    }
}
