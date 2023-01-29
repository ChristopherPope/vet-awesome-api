using VetAwesome.Bll.RandomDataMakers;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomPhoneNumberMakerTests
    {
        [Test]
        public void MakePhoneNumber()
        {
            // ARRANGE
            using var mock = AutoMock.GetLoose();
            var maker = mock.Create<RandomPhoneNumberMaker>();

            // ACT
            var actualPhoneNumber = maker.MakePhoneNumber();

            // ASSERT
            actualPhoneNumber.Should().NotBeNull();
            actualPhoneNumber.Length.Should().Be(14);
        }
    }
}
