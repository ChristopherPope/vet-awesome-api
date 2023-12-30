using VetAwesome.Application.Abstract;

namespace VetAwesome.Application.Appointments.Queries;
public class AppointmentsResponse : VetAwesomeResponse, IAppointmentsResponse
{
    public IEnumerable<AppointmentDto>? Appointments { get; private set; }

    public static AppointmentsResponse Success(IEnumerable<AppointmentDto> appointments)
    {
        return new AppointmentsResponse { IsFailure = false, Appointments = appointments };
    }

    public static AppointmentsResponse Failure(string failureMessage)
    {
        return new AppointmentsResponse { IsFailure = true, FailureMessage = failureMessage };
    }
}
