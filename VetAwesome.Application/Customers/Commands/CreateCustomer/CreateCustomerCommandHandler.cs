using MediatR;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;

namespace VetAwesome.Application.Customers.Commands.CreateCustomer;

internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository customerRepo;
    private readonly IUnitOfWork unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepo, IUnitOfWork unitOfWork)
    {
        this.customerRepo = customerRepo;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(request.Name, request.StreetAddress, request.City, request.Zip, request.StateId, request.Phone);
        customerRepo.Create(customer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return customer;
    }
}