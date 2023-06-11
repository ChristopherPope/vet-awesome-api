using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Enums;
using VetAwesome.Infrastructure.Persistence;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder.EntitySeeders;

internal sealed class AppointmentSeeder : EntitySeeder<Appointment>, IAppointmentSeeder
{
    private readonly ILogger<AppointmentSeeder> logger;
    private readonly IUserSeeder userSeeder;
    private readonly IPetSeeder petSeeder;
    private CancellationToken cancellationToken = default(CancellationToken);
    private List<User> vets = new();
    private readonly Dictionary<DateTime, List<User>> vetsBusyUntil = new();

    public IReadOnlyCollection<Appointment> Appointments => EntityList;

    public AppointmentSeeder(ILogger<AppointmentSeeder> logger
        , VetAwesomeDb vetDb
        , IUserSeeder userSeeder
        , IPetSeeder petSeeder)
        : base(logger, vetDb)
    {
        this.userSeeder = userSeeder;
        this.petSeeder = petSeeder;
        this.logger = logger;
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        this.cancellationToken = cancellationToken;
        await petSeeder.LoadAllPetsAsync(cancellationToken);
        await userSeeder.LoadAllUsersAsync(cancellationToken);

        vets = userSeeder.Users
            .Where(u => u.UserRoleId == (int)RoleTypes.Veterinarian)
            .ToList();

        Guard.IsNull(entityList);
        entityList = new();

        DateTime forDay = DateTime.Now.AddDays(-5);
        for (int i = 0; i <= 10; i++)
        {
            CreateAppointmentsForDay(forDay);
            forDay = forDay.AddDays(1);
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }

    private void CreateAppointmentsForDay(DateTime forDay)
    {
        var startTime = new DateTime(forDay.Year, forDay.Month, forDay.Day, 8, 0, 0);
        for (var i = 0; i < 36; i++)
        {
            CreateAppointmentsForStartTime(startTime);
            startTime = startTime.AddMinutes(15);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
        }
    }

    private void PullFreeVets(DateTime startTime)
    {
        if (!vetsBusyUntil.ContainsKey(startTime))
        {
            return;
        }

        vets.AddRange(vetsBusyUntil[startTime]);
        vetsBusyUntil.Remove(startTime);
    }

    private void RecordVetInUse(User vet, DateTime busyUntil)
    {
        if (!vetsBusyUntil.ContainsKey(busyUntil))
        {
            vetsBusyUntil.Add(busyUntil, new List<User>());
        }

        vetsBusyUntil[busyUntil].Add(vet);
        vets.RemoveAt(vets.FindIndex(v => v.Id == vet.Id));
    }

    private void CreateAppointmentsForStartTime(DateTime startTime)
    {
        PullFreeVets(startTime);
        var numAppointments = rand.Next(0, vets.Count() + 1);
        for (var i = 0; i < numAppointments; i++)
        {
            if (!vets.Any())
            {
                return;
            }

            var vet = GetRandomElement(vets);
            var pet = GetRandomElement(petSeeder.Pets);
            var endTime = startTime
                .AddMinutes(rand.Next(1, 5) * 15);

            var appointment = pet.AddAppointment(startTime, endTime, vet);
            entityList!.Add(appointment);
            RecordVetInUse(vet, endTime);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
        }
    }
}
