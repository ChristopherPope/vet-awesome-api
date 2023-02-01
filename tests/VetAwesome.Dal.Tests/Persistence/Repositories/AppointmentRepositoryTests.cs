using VetAwesome.Dal.Tests.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class AppointmentRepositoryTests : RepositoryTests
    {
        [Test]
        public void ReadAppointments()
        {
            // ARRANGE
            using var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose();

            // ACT

            // ASSERT
        }
    }
}
