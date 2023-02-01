using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<AppointmentEntity>, IAppointmentRepository
    {
        public AppointmentRepository(DbContext dbContext) : base(dbContext) { }

        public IQueryable<AppointmentEntity> ReadAppointments(TimeOnly inclusiveStart, TimeOnly inclusiveEnd, int? forVetId = null)
        {
            var query = (from a in entities
                        .Include(a => a.Pet)
                            .ThenInclude(p => p.PetBreed)
                        .Include(a => a.Customer)
                            .ThenInclude(c => c.Household)
                                .ThenInclude(h => h.State)
                         where a.StartTime >= DateTime.Now.Date + inclusiveStart.ToTimeSpan() &&
                             a.EndTime <= DateTime.Now.Date + inclusiveEnd.ToTimeSpan()
                         select a);

            if (forVetId.HasValue)
            {
                query = query.Where(a => a.CustomerId == forVetId.Value);
            }

            return query;
        }
    }
}
