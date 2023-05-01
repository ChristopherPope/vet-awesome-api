using VetAwesome.Application.Abstractions.Messaging;
using VetAwesome.Domain.Repositories;
using VetAwesome.Domain.Results;

namespace VetAwesome.Application.Customers.CreateCustomer;

internal sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository customerRepo;
    private readonly IUnitOfWork unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepo, IUnitOfWork unitOfWork)
    {
        this.customerRepo = customerRepo;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        //var customer = Customer.Create(request.Name, request.StreetAddress, request.City, request.Zip, request.StateId, request.Phone);
        //await customerRepo.CreateAsync(customer, cancellationToken);
        //await unitOfWork.SaveChangesAsync(cancellationToken);

        //return customer.Id;

        return null;
    }
}