using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetAwesome.Application.Customers.CreateCustomer;
using VetAwesome.Domain.Results;
using VetAwesome.Presentation.Contracts.Customers;

namespace VetAwesome.Presentation.Controllers;

[Route("api/[Controller]")]
public sealed class CustomersController : ApiController
{
    public CustomersController(ISender sender)
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(
        [FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateCustomerCommand(
            request.Name,
            request.StreetAddress,
            request.City,
            request.Zip,
            request.StateId,
            request.Phone);

        Result<int> result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            nameof(CreateCustomer),
            new { id = result.Value },
            result.Value);
    }
}
