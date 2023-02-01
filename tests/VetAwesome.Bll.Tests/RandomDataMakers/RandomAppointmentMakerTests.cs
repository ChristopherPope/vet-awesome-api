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

            mockUow.Setup(m => m.Users).Returns(mockUserRepo.Object);

            var vets = new List<UserEntity>
            {
                MakeVet(),
                MakeVet(),
                MakeVet()
            };
            mockUserRepo.Setup(m => m.ReadAll()).Returns(vets.AsQueryable());

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
                UserRoleId = (int)UserRoleType.Veterinarian
            };
        }
    }
}
