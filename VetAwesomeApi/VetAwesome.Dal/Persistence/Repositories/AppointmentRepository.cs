using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<AppointmentEntity>, IAppointmentRepository
    {
        public AppointmentRepository(DbContext dbContext) : base(dbContext) { }
    }
}
