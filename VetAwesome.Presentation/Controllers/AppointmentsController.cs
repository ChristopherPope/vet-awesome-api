using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using VetAwesome.Application.CommandsAndQueries.Appointments.Queries.GetAppointments;
using VetAwesome.Application.Dtos;

namespace VetAwesome.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ApiController
{
    public AppointmentsController(ISender mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments([Required] DateTime startDate, [Required] DateTime endDate, CancellationToken cancellationToken)
    {
        var request = new GetAppointmentsQuery(startDate, endDate);
        var appointments = await mediator.Send(request, cancellationToken);

        return new JsonResult(appointments, new JsonSerializerOptions());

        //return Ok(appointments);
    }

}
