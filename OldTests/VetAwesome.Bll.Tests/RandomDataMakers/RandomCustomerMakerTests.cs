using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Bll.RandomDataMakers;
using VetAwesome.Dal.Interfaces;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomCustomerMakerTests
    {
        [Test]
        public void MakeCustomer()
        {
            // ARRANGE
            using var mock = AutoMock.GetLoose();
            var mockPhoneNumberMaker = mock.Mock<IRandomPhoneNumberMaker>();
            var mockNameMaker = mock.Mock<IRandomNameMaker>();

            var mockUow = mock.Mock<IUnitOfWork>();
            var mockStatesRepo = mock.Mock<IStatesRepository>();
            mockUow.Setup(m => m.States).Returns(mockStatesRepo.Object);
            var state = new StateEntity { Name = "Florida", Abbreviation = "FL" };
            mockStatesRepo.Setup(m => m.ReadAll()).Returns(Enumerable.Repeat(state, 1).AsQueryable());

            mockPhoneNumberMaker.Setup(m => m.MakePhoneNumber()).Returns("(111) 222-3333");
            mockNameMaker.Setup(m => m.MakeFirstName()).Returns("Bugs");
            mockNameMaker.Setup(m => m.MakeLastName()).Returns("Bunny");

            var maker = mock.Create<RandomCustomerMaker>();

            // ACT
            var actualCustomer = maker.MakeCustomer();

            // ASSERT
            actualCustomer.Should().NotBeNull();
            actualCustomer.Name.Should().BeEquivalentTo("Bugs Bunny");
        }
    }
}
