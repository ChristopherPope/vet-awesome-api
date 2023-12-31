using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetAwesome.API.Abstract;
using VetAwesome.Application.Appointments.Queries;

namespace VetAwesome.API.Appointments;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : VetAwesomeController
{
    public AppointmentsController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetApoinmentsForToday()
    {
        var query = new GetAppointmentsListQuery(DateOnly.FromDateTime(DateTime.Now));
        var response = await mediator.Send(query);

        return Ok(response.Appointments);
    }
}
