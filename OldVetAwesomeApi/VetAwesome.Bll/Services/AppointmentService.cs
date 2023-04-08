using AutoMapper;
using Microsoft.AspNetCore.Http;
using VetAwesome.Bll.Dtos;
using VetAwesome.Bll.Interfaces.Services;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.Services
{
    public class AppointmentService : BaseService, IAppointmentService
    {
        public AppointmentService(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor httpAccessor) : base(uow, mapper, httpAccessor)
        {
        }

        public IEnumerable<Appointment> ReadAppointments(DateTime inclusiveStart, DateTime inclusiveEnd)
        {
            var query = uow.Appointments.ReadAppointments(inclusiveStart, inclusiveEnd);

            return mapper.ProjectTo<Appointment>(query).ToList();
        }
    }
}
