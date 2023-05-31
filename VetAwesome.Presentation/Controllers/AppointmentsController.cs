using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetAwesome.Application.Appointments.Queries.GetAppointmentsForDay;
using VetAwesome.Application.Dtos;

namespace VetAwesome.Presentation.Controllers;

public class AppointmentsController : ApiController
{
    public AppointmentsController(ISender mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("/")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsForToday(CancellationToken cancellationToken)
    {
        var request = new GetAppointmentsForDayQuery(DateOnly.FromDateTime(DateTime.Now));
        var appointments = await mediator.Send(request, cancellationToken);

        return Ok(appointments);
    }

}
