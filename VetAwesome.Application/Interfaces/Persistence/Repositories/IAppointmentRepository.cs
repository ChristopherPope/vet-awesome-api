using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Appointments;

namespace VetAwesome.Persistence.Repositories.Interfaces;
public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<IEnumerable<Appointment>> ReadForDayAsync(DateOnly day);
}
