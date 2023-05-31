using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Interfaces.Persistence.Repositories;

public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<IEnumerable<Appointment>> ReadAllAppointmentsForDayAsync(DateOnly forDay, CancellationToken cancellationToken);
}
