using VetAwesome.Application.Abstractions.Messaging;

namespace VetAwesome.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(
    string Name,
    string StreetAddress,
    string City,
    string Zip,
    int StateId,
    string Phone) : ICommand<int>;
