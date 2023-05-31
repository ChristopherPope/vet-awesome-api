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

    public async Task<IEnumerable<Appointment>> ReadAllAppointmentsForDayAsync(DateOnly forDay, CancellationToken cancellationToken)
    {
        var begin = forDay.ToDateTime(new TimeOnly(0, 0, 0, 0));
        var end = forDay.ToDateTime(new TimeOnly(23, 59, 59, 999));

        return await (from a in Entities
                .Include(a => a.Pet).ThenInclude(p => p.Customer)
                .Include(a => a.Pet).ThenInclude(p => p.PetBreed).ThenInclude(b => b.PetType)
                .Include(a => a.Veterinarian).ThenInclude(v => v.UserRole)
                      where a.StartTime >= begin && a.StartTime <= end
                      orderby a.StartTime
                      select a)
                .ToListAsync(cancellationToken);

    }
}
