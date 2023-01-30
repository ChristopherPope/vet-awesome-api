using VetAwesome.Bll.Enums;
using VetAwesome.Bll.RandomDataMakers;
using VetAwesome.Dal.Interfaces;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomAppointmentMakerTests
    {
        [Test]
        public void MakeAppointments()
        {
            // ARRANGE
            var mock = AutoMock.GetLoose();
            var mockUow = mock.Mock<IUnitOfWork>();
            var mockUserRepo = mock.Mock<IUserRepository>();
            var mockHouseholdRepo = mock.Mock<IHouseholdRepository>();

            mockUow.Setup(m => m.Users).Returns(mockUserRepo.Object);
            mockUow.Setup(m => m.Households).Returns(mockHouseholdRepo.Object);

            var vets = new List<UserEntity>
            {
                MakeVet(),
                MakeVet(),
                MakeVet()
            };
            mockUserRepo.Setup(m => m.ReadAll()).Returns(vets.AsQueryable());

            var households = new List<HouseholdEntity>
            {
                MakeHousehold(),
                MakeHousehold(),
                MakeHousehold()
            };
            mockHouseholdRepo.Setup(m => m.ReadAll()).Returns(households.AsQueryable());

            var maker = mock.Create<RandomAppointmentMaker>();

            // ACT
            var actualAppointments = maker.MakeAppointments(TimeOnly.FromDateTime(DateTime.Now));

            // ASSERT
            actualAppointments.Should().NotBeNull();
        }

        private UserEntity MakeVet()
        {
            return new UserEntity
            {
                Name = "Road Runner",
                RoleId = (int)RoleType.Veterinarian
            };
        }

        private HouseholdEntity MakeHousehold()
        {
            var household = new HouseholdEntity
            {
                StreetAddress1 = "Fangling Ave."
            };

            household.Customers.Add(new CustomerEntity
            {
                Name = "Bugs Bunny",
            });

            household.Pets.Add(new PetEntity
            {
                Name = "Fred"
            });

            return household;
        }
    }
}
