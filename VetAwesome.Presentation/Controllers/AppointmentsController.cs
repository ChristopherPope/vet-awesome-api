using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using VetAwesome.Application.CommandsAndQueries.Appointments.DeleteAppointment;
using VetAwesome.Application.CommandsAndQueries.Appointments.GetAppointments;
using VetAwesome.Application.Dtos;
using VetAwesome.Application.Exceptions;

namespace VetAwesome.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ApiController
{
    public AppointmentsController(ISender mediator) : base(mediator)
    {
    }

    [HttpDelete]
    [Route("{appointmentId}")]
    public async Task<IActionResult> DeleteAppointment([Required] int appointmentId)
    {
        try
        {
            var command = new DeleteAppointmentCommand(appointmentId);
            await mediator.Send(command);
            return NoContent();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
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
