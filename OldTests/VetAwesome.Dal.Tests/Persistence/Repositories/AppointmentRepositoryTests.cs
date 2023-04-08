using VetAwesome.Dal.Tests.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class AppointmentRepositoryTests : RepositoryTests
    {
        [Test]
        public void ReadAppointments()
        {
            // ARRANGE
            var dbContext = CreateContext();
            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(dbContext).As<DbContext>());
            var expectedAppointment = GetRandomElement(CreateRandomAppointments(dbContext));
            var startTime = expectedAppointment.StartTime.Date;
            var endTime = startTime.AddHours(23);

            var repo = mock.Create<AppointmentRepository>();

            // ACT
            var actualAppointments = repo.ReadAppointments(startTime, endTime);

            // ASSERT
            actualAppointments.Should().NotBeNull();
            actualAppointments.Should().HaveCount(1);
            actualAppointments.First().Should().BeEquivalentTo(expectedAppointment);
        }
    }
}
