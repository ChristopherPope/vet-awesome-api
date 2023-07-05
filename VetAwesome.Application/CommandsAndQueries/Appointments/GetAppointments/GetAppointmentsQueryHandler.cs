using AutoMapper;
using MediatR;
using VetAwesome.Application.Dtos;
using VetAwesome.Application.Interfaces.Persistence;

namespace VetAwesome.Application.CommandsAndQueries.Appointments.GetAppointments;

internal sealed class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, IEnumerable<AppointmentDto>>
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public GetAppointmentsQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<AppointmentDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var appointmentEntities = await uow.Appointments.ReadAppointments(request.StartTimeInclusive, request.EndTimeInclusive, cancellationToken);

        return mapper.Map<IEnumerable<AppointmentDto>>(appointmentEntities);
    }
}
