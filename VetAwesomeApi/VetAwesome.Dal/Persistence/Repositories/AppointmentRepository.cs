using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<AppointmentEntity>, IAppointmentRepository
    {
        public AppointmentRepository(DbContext dbContext) : base(dbContext) { }

        public IQueryable<AppointmentEntity> ReadAppointments(DateTime inclusiveStart, DateTime inclusiveEnd)
        {
            return (from a in entities
                        .Include(a => a.Pet)
                            .ThenInclude(p => p.PetBreed)
                        .Include(a => a.Pet)
                            .ThenInclude(p => p.Customer)
                                .ThenInclude(c => c.State)
                    where a.StartTime >= inclusiveStart && a.EndTime <= inclusiveEnd
                    select a);
        }
    }
}
