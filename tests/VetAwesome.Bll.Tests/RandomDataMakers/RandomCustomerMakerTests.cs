using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Bll.RandomDataMakers;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomCustomerMakerTests
    {
        [Test]
        public void MakeCoupleOrSingle()
        {
            // ARRANGE
            using var mock = AutoMock.GetLoose();
            var mockPhoneNumberMaker = mock.Mock<IRandomPhoneNumberMaker>();
            var mockNameMaker = mock.Mock<IRandomNameMaker>();

            mockPhoneNumberMaker.Setup(m => m.MakePhoneNumber()).Returns("(111) 222-3333");
            mockNameMaker.Setup(m => m.MakeMaleName()).Returns("Bugs");
            mockNameMaker.Setup(m => m.MakeFemaleName()).Returns("Betty");
            mockNameMaker.Setup(m => m.MakeLastName()).Returns("Bunny");

            var maker = mock.Create<RandomCustomerMaker>();

            // ACT
            var actualCustomers = maker.MakeCoupleOrSingle();

            // ASSERT
            actualCustomers.Should().NotBeNull();
            actualCustomers.Should().NotBeEmpty();
            actualCustomers.Should().HaveCountLessThan(3);

            AssertCustomer(actualCustomers.First());
            AssertCustomer(actualCustomers.Last());
        }

        private void AssertCustomer(CustomerEntity customer)
        {
            customer.Should().NotBeNull();
            customer.PhoneNumber.Should().NotBeNullOrEmpty();
        }
    }
}
