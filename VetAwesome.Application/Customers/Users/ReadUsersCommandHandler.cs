using MediatR;
using VetAwesome.Application.Interfaces.Persistence;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Customers.Users;

internal sealed class ReadUsersCommandHandler : IRequestHandler<ReadUsersCommand, IEnumerable<User>>
{
    private readonly IUnitOfWork unitOfWork;

    public ReadUsersCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> Handle(ReadUsersCommand request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Users.ReadAllAsync(cancellationToken);
    }
}