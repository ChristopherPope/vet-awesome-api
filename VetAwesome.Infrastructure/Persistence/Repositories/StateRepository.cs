using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal sealed class StateRepository : Repository<State>, IStateRepository
{
    public StateRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.States)
    {
    }
}
