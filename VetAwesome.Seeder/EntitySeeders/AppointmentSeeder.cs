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
        await petSeeder.LoadAllPetsAsync(cancellationToken);
        await userSeeder.LoadAllUsersAsync(cancellationToken);

        Guard.IsNull(entityList);
        entityList = new();

        var startTime = new TimeOnly(8, 0, 0);
        for (var i = 0; i < 32; i++)
        {
            startTime = startTime.AddMinutes(i * 15);
            CreateAppointments(startTime);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
        }

        await CreateAllEntitiesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await DeleteAllEntitiesAsync(cancellationToken);
    }

    private void CreateAppointments(TimeOnly startTime)
    {
        var vets = userSeeder.Users.Where(u => u.UserRoleId == (int)RoleTypes.Veterinarian);
        var numAppointments = rand.Next(0, vets.Count());
        for (var i = 0; i < numAppointments; i++)
        {
            var vet = GetRandomElement(vets);
            var pet = GetRandomElement(petSeeder.Pets);
            var endTime = startTime
                .AddMinutes(rand.Next(1, 5) * 15);

            var appointment = pet.AddAppointment(SetTimeToToday(startTime), SetTimeToToday(endTime), vet);
            entityList!.Add(appointment);
        }
    }

    private DateTime SetTimeToToday(TimeOnly time)
    {
        var today = DateTime.Now.Date;
        today += time.ToTimeSpan();

        return today;
    }
}
