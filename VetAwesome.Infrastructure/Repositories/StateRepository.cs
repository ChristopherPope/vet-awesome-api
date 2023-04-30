using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Repositories;

internal sealed class StateRepository : Repository<State>, IStateRepository
{
    public StateRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.States)
    {
    }
}
