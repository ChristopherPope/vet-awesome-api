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
        return await Entities.Include(a => a.Pet)
            .ThenInclude(p => p.Customer)
            .Include(a => a.Pet)
            .ThenInclude(p => p.PetBreed)
            .ThenInclude(b => b.PetType)
            .Include(a => a.Veterinarian)
            .ToListAsync();
    }
}
