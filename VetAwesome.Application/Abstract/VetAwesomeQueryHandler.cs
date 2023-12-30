using VetAwesome.Application.Interfaces.Persistence;

namespace VetAwesome.Application.Abstract;

internal abstract class VetAwesomeQueryHandler
{
    protected readonly IUnitOfWork uow;

    public VetAwesomeQueryHandler(IUnitOfWork uow)
    {
        this.uow = uow;
    }
}
