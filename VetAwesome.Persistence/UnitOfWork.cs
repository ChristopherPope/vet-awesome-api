using VetAwesome.Application.Interfaces.Persistence;
using VetAwesome.Persistence.Repositories;
using VetAwesome.Persistence.Repositories.Interfaces;
using VetAwesome.Seeder.Database;

namespace VetAwesome.Persistence;
internal sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VetAwesomeDb dbContext;

    public IAppointmentRepository Appointments => appointments.Value;

    private readonly Lazy<IAppointmentRepository> appointments;

    public UnitOfWork(VetAwesomeDb dbContext)
    {
        this.dbContext = dbContext;

        appointments = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(dbContext));
    }

    public async Task<int> CommitAsync()
    {
        return await dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        dbContext?.Dispose();
    }
}
