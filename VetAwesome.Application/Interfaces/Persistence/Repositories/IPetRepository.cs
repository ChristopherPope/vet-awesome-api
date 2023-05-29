using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Interfaces.Persistence.Repositories;

public interface IPetRepository : IRepository<Pet>
{
    Task<IEnumerable<Pet>> ReadAllAsync(CancellationToken cancellationToken);
}
