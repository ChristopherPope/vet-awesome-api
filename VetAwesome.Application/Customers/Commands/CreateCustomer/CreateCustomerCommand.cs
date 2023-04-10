using MediatR;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Entities.EntityIds;

namespace VetAwesome.Application.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand(
    string Name,
    string StreetAddress,
    string City,
    string Zip,
    StateId StateId,
    string Phone) : IRequest<Customer>;
