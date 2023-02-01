using VetAwesome.Dal.Entities;

namespace VetAwesome.Dal.Interfaces.Persistence.Repositories
{
    public interface IAppointmentRepository : IGenericRepository<AppointmentEntity>
    {
        IQueryable<AppointmentEntity> ReadAppointments(TimeOnly inclusiveStart, TimeOnly inclusiveEnd, int? forUserId = null);
    }
}
