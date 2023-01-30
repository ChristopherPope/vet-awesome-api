using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Bll.Interfaces.RandomEntityMaker;
using VetAwesome.Bll.RandomDataMakers;
using VetAwesome.Dal.Interfaces;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomHouseholdMakerTests
    {
        [Test]
        public void MakeHousehold()
        {
            // ARRANGE
            var mock = AutoMock.GetLoose();
            var mockUow = mock.Mock<IUnitOfWork>();
            var mockStateRepo = mock.Mock<IStatesRepository>();
            var states = new List<StateEntity> { new StateEntity { Name = "Louisiana", Abbreviation = "LA" } };
            mockStateRepo.Setup(m => m.ReadAll()).Returns(states.AsQueryable());
            mockUow.Setup(u => u.States).Returns(mockStateRepo.Object);

            var mockCustomerMaker = mock.Mock<IRandomCustomerMaker>();
            mockCustomerMaker.Setup(m => m.MakeCoupleOrSingle()).Returns(Enumerable.Repeat(new CustomerEntity { Name = "Bugs Bunny" }, 1));

            var mockPetMaker = mock.Mock<IRandomPetMaker>();
            mockPetMaker.Setup(m => m.MakePet()).Returns(new PetEntity { Name = "Fred" });

            var mockPhoneNumberMaker = mock.Mock<IRandomPhoneNumberMaker>();
            mockPhoneNumberMaker.Setup(m => m.MakePhoneNumber()).Returns("(111) 222-3333");

            var maker = mock.Create<RandomHouseholdMaker>();

            // ACT
            var actualHousehold = maker.MakeHousehold();

            // ASSERT
            actualHousehold.Should().NotBeNull();
            actualHousehold.State.Should().NotBeNull();
            actualHousehold.Pets.Should().NotBeNullOrEmpty();
            actualHousehold.Customers.Should().NotBeNullOrEmpty();
            actualHousehold.StreetAddress1.Should().NotBeNullOrEmpty();
            actualHousehold.City.Should().NotBeNullOrEmpty();
            actualHousehold.ZipCode.Should().NotBeNullOrEmpty();
        }
    }
}
