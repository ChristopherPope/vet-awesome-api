using VetAwesome.Dal.Entities;

namespace VetAwesome.Bll.Interfaces.RandomDataMakers
{
    public interface IRandomAppointmentMaker
    {
        IEnumerable<AppointmentEntity> MakeAppointments(TimeOnly startTime);
    }
}
