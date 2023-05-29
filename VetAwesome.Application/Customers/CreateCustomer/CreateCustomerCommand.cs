
using MediatR;

namespace VetAwesome.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(
    string Name,
    string StreetAddress,
    string City,
    string Zip,
    int StateId,
    string Phone) : IRequest<int>;
