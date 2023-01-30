using VetAwesome.Bll.RandomDataMakers;

namespace VetAwesome.Bll.Tests.RandomDataMakers
{
    public class RandomNameMakerTests
    {
        private readonly static List<(string name, Func<RandomNameMaker, string> makeName)> testCaseSource = new()
        {
            (name: "FirstName", makeName: (maker) => maker.MakeFirstName()),
            (name: "LastName", makeName: (maker) => maker.MakeLastName()),
            (name: "MaleName", makeName: (maker) => maker.MakeMaleName()),
            (name: "FemaleName", makeName: (maker) => maker.MakeFemaleName()),
        };

        [Test]
        [TestCaseSource(nameof(testCaseSource))]
        public void MakeName((string name, Func<RandomNameMaker, string> makeName) testCase)
        {
            List<string> fred = new();
            fred.Where(s => s.Length > 5);

            // ARRANGE
            var mock = AutoMock.GetLoose();
            var maker = mock.Create<RandomNameMaker>();

            // ACT
            var actualValue = testCase.makeName(maker);

            // ASSERT
            actualValue.Should().NotBeNullOrEmpty();
        }
    }
}
