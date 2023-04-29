namespace VetAwesome.Domain.Results;

public static class DomainErrors
{
    public static class Customer
    {
        public static readonly Error CreationFailed = new(
            "Customer.Create",
            "Failed to create the customer.");
    }
}