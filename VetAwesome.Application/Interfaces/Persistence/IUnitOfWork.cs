using VetAwesome.Persistence.Repositories.Interfaces;

namespace VetAwesome.Application.Interfaces.Persistence;
public interface IUnitOfWork
{
    IAppointmentRepository Appointments { get; }

    Task<int> CommitAsync();
}
