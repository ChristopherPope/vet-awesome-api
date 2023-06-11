using Microsoft.EntityFrameworkCore;
using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal sealed class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.Appointments)
    {
    }

    public async Task<IEnumerable<Appointment>> ReadAppointments(DateTime startTimeInclusive, DateTime endTimeInclusive, CancellationToken cancellationToken)
    {
        return await (from a in Entities
                .Include(a => a.Pet).ThenInclude(p => p.Customer).ThenInclude(c => c.State)
                .Include(a => a.Pet).ThenInclude(p => p.PetBreed).ThenInclude(b => b.PetType)
                .Include(a => a.Veterinarian).ThenInclude(v => v.UserRole)
                      where a.StartTime >= startTimeInclusive && a.StartTime <= endTimeInclusive
                      orderby a.StartTime
                      select a)
                .ToListAsync(cancellationToken);

    }
}
