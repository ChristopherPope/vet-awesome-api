using MediatR;
using VetAwesome.Application.Interfaces.Persistence;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Customers.ReadPets;

internal sealed class ReadPetsCommandHandler : IRequestHandler<ReadPetsCommand, IEnumerable<Pet>>
{
    private readonly IUnitOfWork unitOfWork;

    public ReadPetsCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Pet>> Handle(ReadPetsCommand request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Pets.ReadAllAsync(cancellationToken);
    }
}