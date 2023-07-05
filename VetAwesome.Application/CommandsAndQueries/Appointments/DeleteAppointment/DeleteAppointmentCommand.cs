using MediatR;

namespace VetAwesome.Application.CommandsAndQueries.Appointments.DeleteAppointment;

public sealed record DeleteAppointmentCommand(int AppointmentId) : IRequest;
