using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VetAwesome.Seeder.EntitySeeders.Interfaces;

namespace VetAwesome.Seeder;

internal class Seeder : IHostedService, IAsyncDisposable
{
    private readonly ILogger<Seeder> logger;
    private readonly Task completedTask = Task.CompletedTask;
    private readonly IAppointmentSeeder appointmentSeeder;
    private readonly IReadOnlyList<IEntitySeeder> entityDeletionHierarchy;
    private readonly IReadOnlyList<IEntitySeeder> entityCreationHierarchy;
    private Task? task;

    public Seeder(ILogger<Seeder> logger
        , IStateSeeder stateSeeder
        , IPetTypeSeeder petTypeSeeder
        , IPetSeeder petSeeder
        , IPetBreedSeeder petBreedSeeder
        , ICustomerSeeder customerSeeder
        , IUserRoleSeeder roleSeeder
        , IUserSeeder userSeeder
        , IAppointmentSeeder appointmentSeeder
        , IAddressSeeder addressSeeder
        )
    {
        this.logger = logger;
        this.appointmentSeeder = appointmentSeeder;

        entityDeletionHierarchy =
            [
                appointmentSeeder,
                petSeeder,
                petBreedSeeder,
                petTypeSeeder,
                customerSeeder,
                addressSeeder,
                stateSeeder,
                userSeeder,
                roleSeeder,
            ];

        entityCreationHierarchy =
            [
                roleSeeder,
                userSeeder,
                stateSeeder,
                addressSeeder,
                customerSeeder,
                petTypeSeeder,
                petBreedSeeder,
                petSeeder,
                appointmentSeeder,
            ];
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"The {nameof(Seeder)} is running.");
        var thread = new Thread(new ParameterizedThreadStart(DoWork))
        {
            Name = "Seeder Thread"
        };
        thread.Start(cancellationToken);

        return completedTask;
    }

    private async void DoWork(object? token)
    {
        if (token is null)
        {
            return;
        }

        var option = string.Empty;
        do
        {
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}1 - Create appointments only{Environment.NewLine}2 - Create all entities{Environment.NewLine}{Environment.NewLine}");
            option = Console.ReadLine();

        } while (option != "1" && option != "2");

        if (option == "1")
        {
            await SeedAppointments((CancellationToken)token);
        }
        else
        {
            await SeedAllEntities((CancellationToken)token);
        }
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("{Service} is stopping.", nameof(Seeder));

        return completedTask;
    }

    public ValueTask DisposeAsync()
    {
        task?.Dispose();
        return ValueTask.CompletedTask;
    }

    private async Task SeedAppointments(CancellationToken cancellationToken)
    {
        await appointmentSeeder.DeleteAllAsync(cancellationToken);
        await appointmentSeeder.CreateAsync(cancellationToken);

        logger.LogInformation("Seeding of appointments is completed.");
    }

    private async Task SeedAllEntities(CancellationToken cancellationToken)
    {
        await DeleteEntitiesAsync(cancellationToken);
        await CreateEntitiesAsync(cancellationToken);

        logger.LogInformation("Seeding of entities is completed.");
    }

    private async Task DeleteEntitiesAsync(CancellationToken cancellationToken)
    {
        foreach (var seeder in entityDeletionHierarchy)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await seeder.DeleteAllAsync(cancellationToken);
        }
    }

    private async Task CreateEntitiesAsync(CancellationToken cancellationToken)
    {
        foreach (var seeder in entityCreationHierarchy)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await seeder.CreateAsync(cancellationToken);
        }
    }
}
