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
            MockUserRepo(mock);
            MockCustomerRepo(mock);

            var maker = mock.Create<RandomAppointmentMaker>();

            // ACT
            var actualAppointments = maker.MakeAppointments(TimeOnly.FromDateTime(DateTime.Now));

            // ASSERT
            actualAppointments.Should().NotBeNull();
        }

        private void MockCustomerRepo(AutoMock mock)
        {
            var mockUow = mock.Mock<IUnitOfWork>();
            var mockCustomerRepo = mock.Mock<ICustomerRepository>();
            mockUow.Setup(m => m.Customers).Returns(mockCustomerRepo.Object);

            var customers = new List<CustomerEntity>
            {
                MakeCustomer(),
                MakeCustomer(),
                MakeCustomer(),
                MakeCustomer(),
                MakeCustomer(),
            };
            mockCustomerRepo.Setup(m => m.ReadAll()).Returns(customers.AsQueryable());
        }

        private void MockUserRepo(AutoMock mock)
        {
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
        }

        private CustomerEntity MakeCustomer()
        {
            var customer = new CustomerEntity
            {
                Name = "William Shakespeare",
                City = "Monrovia",
                ZipCode = "21770",
                StateId = 5,
            };

            customer.Pets.Add(MakePet());

            return customer;
        }

        private PetEntity MakePet()
        {
            return new PetEntity
            {
                Name = "fido",
                PetBreed = new PetBreedEntity { Name = "rugrat" }
            };
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
