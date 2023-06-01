using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAwesome.Domain.Results;

namespace VetAwesome.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender mediator;

    protected ApiController(ISender mediator) => this.mediator = mediator;

    protected IActionResult HandleFailure(Result result) =>
    result switch
    {
        { IsSuccess: true } => throw new InvalidOperationException(),
        _ =>
            BadRequest(
                CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error))
    };

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}
