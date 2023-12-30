using MediatR;

namespace VetAwesome.Application.Appointments.Queries;
public class GetAppointmentsListQuery(DateOnly forDay) : IRequest<AppointmentsResponse>
{
    public DateOnly ForDay { get; init; } = forDay;
}
