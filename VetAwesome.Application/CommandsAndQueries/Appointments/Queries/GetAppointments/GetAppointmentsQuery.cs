using MediatR;
using VetAwesome.Application.Dtos;

namespace VetAwesome.Application.CommandsAndQueries.Appointments.Queries.GetAppointments;

public sealed record GetAppointmentsQuery(DateTime StartTimeInclusive, DateTime EndTimeInclusive)
    : IRequest<IEnumerable<AppointmentDto>>;
