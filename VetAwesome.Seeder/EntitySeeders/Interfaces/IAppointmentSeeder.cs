using VetAwesome.Domain.Entities;

namespace VetAwesome.Seeder.EntitySeeders.Interfaces;

internal interface IAppointmentSeeder : IEntitySeeder
{
    IReadOnlyCollection<Appointment> Appointments { get; }
}
