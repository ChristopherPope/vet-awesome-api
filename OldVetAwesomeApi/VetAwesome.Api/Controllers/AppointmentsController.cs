using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VetAwesome.Bll.Dtos;
using VetAwesome.Bll.Interfaces.Services;

namespace VetAwesome.Api.Controllers
{
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentsSvc;

        public AppointmentsController(ILogger<AppointmentsController> logger, IAppointmentService appointmentsSvc)
            : base(logger)
        {
            this.appointmentsSvc = appointmentsSvc;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "A list of appointments in the time range.")]
        [SwaggerOperation("Returns a list of appointments in the time range.")]
        public ActionResult<IEnumerable<Appointment>> GetAppointments(DateTime inclusiveStart, DateTime inclusiveEnd)
        {
            return appointmentsSvc.ReadAppointments(inclusiveStart, inclusiveEnd).ToList();
        }
    }
}
