namespace VetAwesome.Presentation.Contracts.Customers;

public sealed record CreateCustomerRequest(string Name,
    string StreetAddress,
    string City,
    string Zip,
    int StateId,
    string Phone);