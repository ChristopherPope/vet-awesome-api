using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VetAwesome.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class CustomersController : ApiController
{
    public CustomersController(ISender mediator)
        : base(mediator)
    {
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateCustomer(
    //    [FromBody] CreateCustomerRequest request,
    //    CancellationToken cancellationToken)
    //{
    //    var command = new CreateCustomerCommand(
    //        request.Name,
    //        request.StreetAddress,
    //        request.City,
    //        request.Zip,
    //        request.StateId,
    //        request.Phone);

    //    Result<int> result = await Sender.Send(command, cancellationToken);

    //    if (result.IsFailure)
    //    {
    //        return HandleFailure(result);
    //    }

    //    return CreatedAtAction(
    //        nameof(CreateCustomer),
    //        new { id = result.Value },
    //        result.Value);
    //}
}
