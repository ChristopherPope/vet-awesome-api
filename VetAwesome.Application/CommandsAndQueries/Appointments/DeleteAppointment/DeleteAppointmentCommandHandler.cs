using MediatR;
using VetAwesome.Application.Exceptions;
using VetAwesome.Application.Interfaces.Persistence;

namespace VetAwesome.Application.CommandsAndQueries.Appointments.DeleteAppointment;

internal sealed class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointmentEntity = await unitOfWork.Appointments.ReadByIdAsync(request.AppointmentId) ?? throw new EntityNotFoundException($"No appointment with the ID {request.AppointmentId} exists.");

        await unitOfWork.Appointments.DeleteByIdAsync(request.AppointmentId);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
