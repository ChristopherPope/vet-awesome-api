using Microsoft.EntityFrameworkCore;
using VetAwesome.Bll.Enums;
using VetAwesome.Bll.Interfaces.RandomDataMakers;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces;

namespace VetAwesome.Bll.RandomDataMakers
{
    public class RandomAppointmentMaker : RandomDataMaker, IRandomAppointmentMaker
    {
        private readonly IUnitOfWork uow;
        private readonly Lazy<List<UserEntity>> allVets;
        private readonly Lazy<List<HouseholdEntity>> households;
        private readonly List<(int vetId, TimeOnly startTime, TimeOnly endTime)> unavailableVets = new();
        private List<UserEntity> AllVets => allVets.Value;
        private List<HouseholdEntity> Households => households.Value;

        public RandomAppointmentMaker(IUnitOfWork uow)
        {
            this.uow = uow;

            households = new Lazy<List<HouseholdEntity>>(() => LoadHouseholds());
            allVets = new Lazy<List<UserEntity>>(() => LoadVets());
        }

        public IEnumerable<AppointmentEntity> MakeAppointments(TimeOnly startTime)
        {
            var vets = GetAvailableVets(startTime);
            var numAppointments = rand.Next(0, vets.Count + 1);
            var appointments = new List<AppointmentEntity>();
            while (appointments.Count < numAppointments)
            {
                var vet = GetRandomElement(vets);
                var household = GetRandomElement(Households);
                var endTime = startTime
                    .AddMinutes(rand.Next(1, 5) * 15);
                appointments.Add(new AppointmentEntity
                {
                    Customer = GetRandomElement(household.Customers),
                    Pet = GetRandomElement(household.Pets),
                    Veterinarian = vet,
                    StartTime = SetTimeToToday(startTime),
                    EndTime = SetTimeToToday(endTime)
                });

                var appointment = appointments.Last();
                unavailableVets.Add(
                    (
                        vetId: appointment.Veterinarian.Id,
                        startTime: TimeOnly.FromDateTime(appointment.StartTime),
                        endTime: TimeOnly.FromDateTime(appointment.EndTime)
                    ));

                vets.Remove(appointment.Veterinarian);
            }

            return appointments;
        }

        private DateTime SetTimeToToday(TimeOnly time)
        {
            var today = DateTime.Now.Date;
            today += time.ToTimeSpan();

            return today;
        }

        private List<UserEntity> GetAvailableVets(TimeOnly startTime)
        {
            unavailableVets.RemoveAll(uv => uv.endTime < startTime);
            var unavailableVetIds = unavailableVets.Select(uv => uv.vetId).ToList();

            return AllVets.Where(v => !unavailableVetIds.Contains(v.Id)).ToList();
        }

        private List<UserEntity> LoadVets()
        {
            return uow.Users
                .ReadAll()
                .Where(u => u.RoleId == (int)RoleType.Veterinarian)
                .ToList();
        }

        private List<HouseholdEntity> LoadHouseholds()
        {
            return uow.Households
                .ReadAll()
                .Include(h => h.Customers)
                .Include(h => h.Pets)
                .ToList();
        }
    }
}
