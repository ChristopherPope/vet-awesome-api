using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VetAwesome.API.Abstract;

public abstract class VetAwesomeController : ControllerBase
{
    protected readonly IMediator mediator;

    public VetAwesomeController(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
