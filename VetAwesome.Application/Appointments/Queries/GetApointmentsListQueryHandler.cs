using MediatR;
using VetAwesome.Application.Abstract;
using VetAwesome.Application.Interfaces.Persistence;
using VetAwesome.Application.Mappers.Interfaces;

namespace VetAwesome.Application.Appointments.Queries;
internal class GetApointmentsListQueryHandler : VetAwesomeQueryHandler, IRequestHandler<GetAppointmentsListQuery, AppointmentsResponse>
{
    private readonly IAppointmentMapper appointmentMapper;

    public GetApointmentsListQueryHandler(IUnitOfWork uow, IAppointmentMapper appointmentMapper)
        : base(uow)
    {
        this.appointmentMapper = appointmentMapper;
    }

    public async Task<AppointmentsResponse> Handle(GetAppointmentsListQuery request, CancellationToken cancellationToken)
    {
        var appointmentEntities = await uow.Appointments.ReadForDayAsync(request.ForDay);

        var response = AppointmentsResponse.Success(appointmentMapper.FromEntities(appointmentEntities));
        var a2 = response.Appointments?.ToList()[0];

        var a = appointmentEntities.ToList()[0];
        a.Veterinarian.FirstName = "bobo";

        return response;
    }
}
