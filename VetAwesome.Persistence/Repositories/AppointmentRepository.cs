using Microsoft.EntityFrameworkCore;
using VetAwesome.Domain.Appointments;
using VetAwesome.Persistence.Repositories.Interfaces;

namespace VetAwesome.Persistence.Repositories;
internal sealed class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(DbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<Appointment>> ReadForDayAsync(DateOnly day)
    {
        return await (from a in Entities.Include(a => a.Veterinarian)
                      where a.StartTime <= day.ToDateTime(TimeOnly.MinValue) && a.EndTime <= day.ToDateTime(TimeOnly.MaxValue)
                      select a)
                      .ToListAsync();
    }
}
