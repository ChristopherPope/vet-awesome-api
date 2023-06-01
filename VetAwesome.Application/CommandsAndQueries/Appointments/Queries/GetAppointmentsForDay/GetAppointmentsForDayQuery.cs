using MediatR;
using VetAwesome.Application.Dtos;

namespace VetAwesome.Application.CommandsAndQueries.Appointments.Queries.GetAppointmentsForDay;

public sealed record GetAppointmentsForDayQuery(DateOnly ForDay)
    : IRequest<IEnumerable<AppointmentDto>>;
