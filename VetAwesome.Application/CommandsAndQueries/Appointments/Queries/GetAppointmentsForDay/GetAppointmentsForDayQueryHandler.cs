using AutoMapper;
using MediatR;
using VetAwesome.Application.Dtos;
using VetAwesome.Application.Interfaces.Persistence;

namespace VetAwesome.Application.CommandsAndQueries.Appointments.Queries.GetAppointmentsForDay;

internal sealed class GetAppointmentsForDayQueryHandler : IRequestHandler<GetAppointmentsForDayQuery, IEnumerable<AppointmentDto>>
{
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public GetAppointmentsForDayQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        this.uow = uow;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<AppointmentDto>> Handle(GetAppointmentsForDayQuery request, CancellationToken cancellationToken)
    {
        var appointmentEntities = await uow.Appointments.ReadAllAppointmentsForDayAsync(request.ForDay, cancellationToken);

        return mapper.Map<IEnumerable<AppointmentDto>>(appointmentEntities);
    }
}
