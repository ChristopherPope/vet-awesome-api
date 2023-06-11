using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Interfaces.Persistence.Repositories;

public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<IEnumerable<Appointment>> ReadAppointments(DateTime startTimeInclusive, DateTime endTimeInclusive, CancellationToken cancellationToken);
}
